using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FaceCopy
{
    public class FaceXML
    {
        public Dictionary<String, List<FaceImage>> Categories;

        public FaceXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<categories></categories>");
            Initialize(xmlDoc);
        }

        public FaceXML(String XMLPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLPath);
            Initialize(xmlDoc);
        }

        private void Initialize(XmlDocument xmlDoc)
        {
            Categories = new Dictionary<string, List<FaceImage>>();

            foreach (XmlElement Category in xmlDoc["categories"].GetElementsByTagName("category"))
            {
                String CategoryName = Category.Attributes["name"].Value;
                List<FaceImage> FaceImageList = new List<FaceImage>();

                foreach (XmlElement Image in Category.GetElementsByTagName("image"))
                {
                    String URL = Image["url"].InnerText;
                    XmlNodeList Paths = Image.GetElementsByTagName("path");
                    List<String> Pathlist = new List<string>();
                    foreach (XmlElement Path in Paths)
                    {
                        Pathlist.Add(Path.InnerText);
                    }
                    String Name = "";
                    if (Image["name"] != null)
                    {
                        Name = Image["name"].InnerText;
                    }

                    FaceImageList.Add(new FaceImage(CategoryName, URL, Pathlist, Name));
                }

                Categories.Add(CategoryName, FaceImageList);
            }
        }

        public void AddCategory(String Category, List<FaceImage> ImageList)
        {
            Categories.Add(Category, ImageList);
        }

        public void Add(String Category, FaceImage Face)
        {
            if (Categories.Keys.Contains(Category))
            {
                Categories[Category].Add(Face);
            }
            else
            {
                List<FaceImage> List = new List<FaceImage>();
                List.Add(Face);
                Categories.Add(Category, List);
            }
        }

        public String ToXML()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<categories>");

            foreach (KeyValuePair<String, List<FaceImage>> KVP in Categories)
            {
                sb.Append("\t<category name=\"").Append(KVP.Key).AppendLine("\">");
                foreach (FaceImage f in KVP.Value)
                {
                    sb.AppendLine("\t\t<image>");
                    sb.Append("\t\t\t<url>").Append(f.URL).AppendLine("</url>");
                    List<String> Paths = f.Paths;
                    foreach (String Path in Paths.Distinct())
                    {
                        sb.Append("\t\t\t<path>").Append(Path).AppendLine("</path>");
                    }
                    if (!String.IsNullOrEmpty(f.Name))
                    {
                        sb.Append("\t\t\t<name>").Append(f.Name).AppendLine("</name>");
                    }
                    sb.AppendLine("\t\t</image>");
                }
                sb.AppendLine("\t</category>");
            }

            sb.AppendLine("</categories>");
            return sb.ToString();
        }

        internal void Remove(string Category, FaceImage faceImage)
        {
            Categories[Category].Remove(faceImage);
        }

        public bool ReplaceInUpdate(string p)
        {
            try
            {
                String update = System.IO.File.ReadAllText(p);
                foreach (KeyValuePair<String, List<FaceImage>> KVP in Categories)
                {
                    foreach (FaceImage f in KVP.Value)
                    {
                        if (!String.IsNullOrEmpty(f.Name))
                        {
                            update = update.Replace(f.Name, "[img]" + f.URL + "[/img]");
                        }
                    }
                }

                String dir = System.IO.Path.GetDirectoryName(p);
                String fn = System.IO.Path.GetFileNameWithoutExtension(p);
                String ext = System.IO.Path.GetExtension(p);
                String newname = dir + System.IO.Path.DirectorySeparatorChar + fn + "_replaced" + ext;
                System.IO.File.WriteAllText(newname, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
