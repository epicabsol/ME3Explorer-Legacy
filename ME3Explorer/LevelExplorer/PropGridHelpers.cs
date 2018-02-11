using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace ME3Explorer.LevelExplorer
{
    /*
     * SharpDX structs don't have C# properties, so they are a massive pain in the PropertyGrid control.
     * These classes are simple types that auto-convert to and from their SharpDX counterparts that play
     * nice with the PropertyGrid.
     */
    
    [TypeConverter(typeof(Vector3TypeConverter))]
    public class Vector3Helper
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3Helper()
        {

        }

        public Vector3Helper(Vector3 value)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
        }

        public Vector3Helper(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3(Vector3Helper other)
        {
            return new Vector3(other.X, other.Y, other.Z);
        }

        public static implicit operator Vector3Helper(Vector3 other)
        {
            return new Vector3Helper(other);
        }

        public override string ToString()
        {
            return "<" + X + "," + Y + "," + Z + ">";
        }

        private class Vector3TypeConverter : ExpandableObjectConverter
        {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(Vector3Helper))
                    return true;

                return base.CanConvertTo(context, destinationType);
            }

            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                    return (value as Vector3Helper).ToString();
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
}
