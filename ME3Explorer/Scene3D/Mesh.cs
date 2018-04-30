using System.Collections.Generic;
using SharpDX;
//using SharpDX.DXGI;
using SharpDX.Direct3D11;

namespace ME3Explorer.Scene3D
{
    // This class exists because typing Mesh<WorldVertex> is a pain.
    public class WorldMesh : Mesh<WorldVertex>
    {
        public WorldMesh(Device Device) : base(Device)
        {

        }

        public WorldMesh(Device Device, List<uint> Indices, List<WorldVertex> Vertices) : base(Device, Indices, Vertices)
        {

        }
    }

    public class Mesh<Vertex> : System.IDisposable where Vertex : VertexBase
    {
        public SharpDX.Direct3D.PrimitiveTopology PrimitiveTopology;
        public List<uint> Indices;
        public List<Vertex> Vertices;
        public SharpDX.Direct3D11.Buffer VertexBuffer { get; private set; } = null;
        public SharpDX.Direct3D11.Buffer IndexBuffer { get; private set; } = null;
        public Vector3 AABBMin { get; private set; }
        public Vector3 AABBMax { get; private set; }
        public Vector3 AABBCenter
        {
            get
            {
                return AABBMin + AABBHalfSize;
            }
        }
        public Vector3 AABBHalfSize
        {
            get
            {
                return (AABBMax - AABBMin) * 0.5f;
            }
        }

        // Creates a new blank mesh.
        public Mesh(SharpDX.Direct3D11.Device Device)
        {
            Indices = new List<uint>();
            Vertices = new List<Vertex>();
            RebuildBuffer(Device);
        }

        // Creates a blank mesh with the given data.
        public Mesh(SharpDX.Direct3D11.Device Device, List<uint> Indices, List<Vertex> Vertices, SharpDX.Direct3D.PrimitiveTopology PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList)
        {
            this.Indices = Indices;
            this.Vertices = Vertices;
            this.PrimitiveTopology = PrimitiveTopology;
            RebuildBuffer(Device);
        }

        public void RebuildBuffer(SharpDX.Direct3D11.Device Device)
        {
            // Dispose all the old stuff
            VertexBuffer?.Dispose();
            IndexBuffer?.Dispose();
            if (Indices.Count == 0 || Vertices.Count == 0) return; // Why build and empty buffer?

            // Reset the AABB
            if (Vertices.Count == 0)
            {
                AABBMin = Vertices[0].Position;
                AABBMax = Vertices[1].Position;
            }
            else
            {
                AABBMin = Vector3.Zero;
                AABBMax = Vector3.Zero;
            }

            // Update the AABB
            float minx = AABBMin.X;
            float miny = AABBMin.Y;
            float minz = AABBMin.Z;
            float maxx = AABBMax.X;
            float maxy = AABBMax.Y;
            float maxz = AABBMax.Z;
            foreach (Vertex v in Vertices)
            {
                minx = v.Position.X < minx ? v.Position.X : minx;
                miny = v.Position.Y < miny ? v.Position.Y : miny;
                minz = v.Position.Z < minz ? v.Position.Z : minz;
                maxx = v.Position.X > maxx ? v.Position.X : maxx;
                maxy = v.Position.Y > maxy ? v.Position.Y : maxy;
                maxz = v.Position.Z > maxz ? v.Position.Z : maxz;
            }
            AABBMin = new Vector3(minx, miny, minz);
            AABBMax = new Vector3(maxx, maxy, maxz);

            // Build the list of floats for the vertex buffer
            List<float> vertexdata = new List<float>();
            foreach (Vertex v in Vertices)
            {
                foreach (float f in v.ToFloats())
                {
                    vertexdata.Add(f);
                }
            }

            // Create and populate the vertex and index buffers
            VertexBuffer = SharpDX.Direct3D11.Buffer.Create<float>(Device, BindFlags.VertexBuffer, vertexdata.ToArray());
            IndexBuffer = SharpDX.Direct3D11.Buffer.Create<uint>(Device, BindFlags.IndexBuffer, Indices.ToArray());
        }

        public void Dispose()
        {
            VertexBuffer?.Dispose();
            IndexBuffer?.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns>The distance to the hit, or less than zero for no hit.</returns>
        public float HitTest(Ray ray)
        {
            BoundingBox aabb = new BoundingBox(AABBMin, AABBMax);
            float distance;
            if (!Collision.RayIntersectsBox(ref ray, ref aabb, out distance))
            {
                return -1.0f;
            }
            float minDistance = float.MaxValue;
            bool hit = false;
            for (int i = 0; i < Indices.Count; i += 3) // Assume triangles
            {
                float triDistance = 0.0f;
                Vector3 v1 = Vertices[(int)Indices[i]].Position;
                Vector3 v2 = Vertices[(int)Indices[i + 1]].Position;
                Vector3 v3 = Vertices[(int)Indices[i + 2]].Position;
                if (Collision.RayIntersectsTriangle(ref ray, ref v1, ref v2, ref v3, out triDistance))
                {
                    hit = true;
                    if (triDistance < minDistance)
                        minDistance = triDistance;
                }
            }

            if (hit)
                return minDistance;
            else
                return -1.0f;
        }

        public static Mesh<PositionColorVertex> CreateGrid(Device device, float minX, float maxX, float minZ, float maxZ, Vector3 color, float stepX = 1.0f, float stepZ = 1.0f)
        {
            List<PositionColorVertex> vertices = new List<PositionColorVertex>();
            List<uint> indices = new List<uint>();

            for (float x = minX; x <= maxX; x += stepX)
            {
                vertices.Add(new PositionColorVertex(new Vector3(x, 0, minZ), color));
                vertices.Add(new PositionColorVertex(new Vector3(x, 0, maxZ), color));
                indices.Add((uint)vertices.Count - 2);
                indices.Add((uint)vertices.Count - 1);
            }

            for (float z = minZ; z <= maxZ; z += stepZ)
            {
                vertices.Add(new PositionColorVertex(new Vector3(minX, 0, z), color));
                vertices.Add(new PositionColorVertex(new Vector3(maxX, 0, z), color));
                indices.Add((uint)vertices.Count - 2);
                indices.Add((uint)vertices.Count - 1);
            }

            return new Mesh<PositionColorVertex>(device, indices, vertices, SharpDX.Direct3D.PrimitiveTopology.LineList);
        }
    }

    /// <summary>
    /// Contains the indices of the three vertices that make up a triangle.
    /// </summary>
    /*[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Triangle
    {
        public uint Vertex1;
        public uint Vertex2;
        public uint Vertex3;

        public Triangle(uint Vertex1, uint Vertex2, uint Vertex3)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Vertex3 = Vertex3;
        }
    }*/

    /// <summary>
    /// The base class for vertices that can be rendered. They must have a position. This is necessary for builtin AABB computation as well.
    /// </summary>
    //[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public class VertexBase
    {
        public Vector3 Position { get; protected set; }

        public VertexBase(Vector3 Position)
        {
            this.Position = Position;
        }

        public virtual float[] ToFloats()
        {
            return new float[] { Position.X, Position.Y, Position.Z };
        }

        public virtual InputElement[] InputElements
        {
            get
            {
                return new InputElement[] { new InputElement("POSITION", 0, SharpDX.DXGI.Format.R32G32B32_Float, 0) };
            }
        }

        public virtual int VertexLength
        {
            get
            {
                return 4 * 3; // four bytes for each of the three channels
            }
        }
    }

    /// <summary>
    /// A simple vertex for testing purposes. 
    /// </summary>
    //[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public class PositionColorVertex : VertexBase
    {
        Vector3 Color;

        public PositionColorVertex() : base(Vector3.Zero)
        {
            Color = Vector3.One;
        }

        public PositionColorVertex(Vector3 Position, Vector3 Color) : base(Position)
        {
            this.Color = Color;
        }

        public override float[] ToFloats()
        {
            return new float[] { Position.X, Position.Y, Position.Z, Color.X, Color.Y, Color.Z };
        }

        public override InputElement[] InputElements
        {
            get
            {
                return new InputElement[] { new InputElement("POSITION", 0, SharpDX.DXGI.Format.R32G32B32_Float, 0), new InputElement("COLOR", 0, SharpDX.DXGI.Format.R32G32B32_Float, 0) };
            }
        }

        public override int VertexLength
        {
            get
            {
                return 4 * 3 + 4 * 3; // four bytes for each of three channels for both position and color.
            }
        }
    }

    public class WorldVertex : VertexBase
    {
        Vector3 Normal;
        Vector2 UV;

        public WorldVertex() : base(Vector3.Zero)
        {

        }

        public WorldVertex(Vector3 Position, Vector3 Normal, Vector2 UV) : base(Position)
        {
            this.Normal = Normal;
            this.UV = UV;
        }

        public override float[] ToFloats()
        {
            return new float[] { Position.X, Position.Y, Position.Z, Normal.X, Normal.Y, Normal.Z, UV.X, UV.Y };
        }

        public override InputElement[] InputElements
        {
            get
            {
                return new InputElement[]
                {
                    new InputElement("POSITION", 0, SharpDX.DXGI.Format.R32G32B32_Float, 0),
                    new InputElement("NORMAL", 0, SharpDX.DXGI.Format.R32G32B32_Float, 0),
                    new InputElement("TEXCOORD", 0, SharpDX.DXGI.Format.R32G32_Float, 0)
                };
            }
        }

        public override int VertexLength
        {
            get
            {
                return 4 * 3 + 4 * 3 + 4 * 2;
            }
        }
    }
}
