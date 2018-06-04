using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SDKGenerator
{
    public class Program
    {
        private const string BaseObject = "MESDK.UnrealObject";
        private static string[] NativeClasses = { "ChildConnection", "Client", "FracturedStaticMesh", "Level", "Model", "NetConnection", "PendingLevel", "ShadowMap1D", "StaticMesh" };

        static void Main(string[] args)
        {
            string objectInfoFilename = "";
            string outputDirectory = "";
            int game = 3;

            // Gather input data
            if (args.Length >= 1)
            {
                objectInfoFilename = args[0];
            }
            else
            {
                System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                dialog.Filter = "JSON File (*.json)|*.json";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    objectInfoFilename = dialog.FileName;
                }
                else
                {
                    return; // User canceled
                }
            }

            if (args.Length >= 2)
            {
                outputDirectory = args[1];
            }
            else
            {
                System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    outputDirectory = dialog.SelectedPath;
                }
                else
                {
                    return; // User canceled
                }
            }

            if (args.Length >= 3)
            {
                game = Int32.Parse(args[2]);
            }
            else
            {
                Console.Write("Game Number > ");
                game = Int32.Parse(Console.ReadLine());
            }

            // Read JSON
            JObject d = JObject.Parse(System.IO.File.ReadAllText(objectInfoFilename));
            string namespaceName = "ME" + game + "SDK";

            // Enums
            Console.WriteLine("Enums");
            foreach (JProperty enumInfo in ((JObject)d["Enums"]).Properties())
            {
                Console.WriteLine("\t" + enumInfo.Name);

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(System.IO.Path.Combine(outputDirectory, enumInfo.Name + ".cs"), false))
                {
                    writer.WriteLine();
                    writer.WriteLine();
                    writer.WriteLine("namespace " + namespaceName);
                    writer.WriteLine("{");

                    writer.WriteLine("\tpublic enum " + enumInfo.Name);
                    writer.WriteLine("\t{");

                    foreach (JValue value in ((JArray)enumInfo.Value).Children())
                    {
                        writer.WriteLine("\t\t" + value.Value + ",");
                    }

                    writer.WriteLine("\t}"); // public enum

                    writer.WriteLine("}"); // namespace
                }
            }

            // Classes
            Console.WriteLine("Classes");
            foreach (JProperty classInfo in ((JObject)d["Classes"]).Properties())
            {
                Console.WriteLine("\t" + classInfo.Name);

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(System.IO.Path.Combine(outputDirectory, classInfo.Name + ".cs"), false))
                {
                    writer.WriteLine();
                    writer.WriteLine();
                    writer.WriteLine("namespace " + namespaceName);
                    writer.WriteLine("{");

                    // Class declaration
                    writer.Write("\tpublic class " + classInfo.Name);
                    if ((string)((JValue)classInfo.Value["baseClass"]).Value != "Object")
                        writer.Write(" : " + ((JValue)classInfo.Value["baseClass"]).Value);
                    else
                        writer.Write(" : " + BaseObject);
                    writer.WriteLine("\r\n\t{");

                    // Constructor
                    writer.WriteLine("\t\tpublic " + classInfo.Name + "(ME3Explorer.Packages.IExportEntry export) : base(export) { }");
                    writer.WriteLine();

                    foreach (JProperty propertyInfo in ((JObject)classInfo.Value["properties"]).Properties())
                    {
                        string sanitizedName = propertyInfo.Name.Replace(':', '_'); // Who thought it was a good idea to throw colons into names???
                        ME3Explorer.Unreal.PropertyType propertyType = (ME3Explorer.Unreal.PropertyType)Convert.ToInt32(((JValue)propertyInfo.Value["type"]).Value);
                        string propertyTypeString = propertyType.ToString();
                        if (propertyType == ME3Explorer.Unreal.PropertyType.ArrayProperty)
                        {
                            string reference = ((JValue)propertyInfo.Value["reference"]).Value as string;
                            string elementType = null;

                            if (Enum.TryParse<ME3Explorer.Unreal.PropertyType>(reference, out ME3Explorer.Unreal.PropertyType primitiveType))
                            {
                                elementType = "ME3Explorer.Unreal." + reference;
                            }
                            else
                            {
                                // Class, struct, or enum type
                                if (NativeClasses.Contains(reference) || ((JObject)d["Classes"]).ContainsKey(reference))
                                    elementType = "ME3Explorer.Unreal.ObjectProperty";
                                else if (((JObject)d["Structs"]).ContainsKey(reference))
                                    elementType = "ME3Explorer.Unreal.StructProperty";
                                else if (((JObject)d["Enums"]).ContainsKey(reference))
                                    elementType = "ME3Explorer.Unreal.EnumProperty";
                                else if (reference == "Property")
                                    elementType = "ME3Explorer.Unreal.UProperty";
                                else
                                    throw new Exception("What the heck???");
                            }

                            propertyTypeString += "<" + elementType + ">";
                        }
                        Console.WriteLine("\t\t" + sanitizedName + " (" + propertyTypeString + ")");

                        /*if (propertyType == ME3Explorer.Unreal.PropertyType.Unknown
                            || propertyType == ME3Explorer.Unreal.PropertyType.None)
                            continue;*/

                        // PropertyGrid helper property


                        // UProperty property
                        writer.WriteLine("\t\tpublic ME3Explorer.Unreal." + propertyTypeString + " " + sanitizedName);
                        writer.WriteLine("\t\t{");

                        writer.WriteLine("\t\t\tget");
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine("\t\t\t\treturn Export.GetProperty<ME3Explorer.Unreal." + propertyTypeString + ">(\"" + sanitizedName + "\");");
                        writer.WriteLine("\t\t\t}"); // get

                        writer.WriteLine("\t\t}"); // property
                        writer.WriteLine();
                    }

                    writer.WriteLine("\t}"); // public class

                    writer.WriteLine("}"); // namespace
                }
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
