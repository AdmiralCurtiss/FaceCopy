using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace FaceCopy
{
    public class FaceImage
    {
        public String URL;
        public List<String> Paths;

        /*
        public String Filename
        {
            get
            {
                if (_Filename == null)
                {
                    _Filename = Path.Substring(Path.LastIndexOf('\\') + 1);
                }
                return _Filename;
            }
        }
        */
        //private String _Filename = null;

        public String Category;
        public String Name;

        public System.Drawing.Image Face {
            get {
                if ( _Face == null ) LoadFace();
                return _Face;
            }
        }
        private System.Drawing.Image _Face = null;

        


        private void LoadFace() {
            // try to load from all paths in order
            foreach (String Path in Paths)
            {
                if (Path != null)
                {
                    try
                    {
                        _Face = System.Drawing.Image.FromFile(Path);
                        break; // successfully loaded, further paths are unneccessary
                    }
                    catch (Exception)
                    {
                        _Face = null;
                    }
                }
            }

            // if face is still null after all paths have been attempted
            if (_Face == null)
            {
                try
                {
                    // try to get from URL
                    WebRequest req = WebRequest.Create(URL);
                    WebResponse response = req.GetResponse();
                    Stream stream = response.GetResponseStream();

                    // write to HDD
                    String folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\FaceCopy";
                    System.IO.Directory.CreateDirectory(folder);

                    String filename = URL.Substring(URL.LastIndexOf('/') + 1);
                    String tmppath = System.IO.Path.GetTempFileName();
                    FileStream fs = System.IO.File.Open(tmppath, FileMode.Create);

                    Byte[] buffer = new byte[1024 * 8];
                    int bytesread = 0;
                    while ((bytesread = stream.Read(buffer, 0, 1024 * 8)) > 0)
                    {
                        fs.Write(buffer, 0, bytesread);
                    }
                    fs.Close();

                    String chksum = GetChecksum(tmppath);
                    String path = folder + "\\" + chksum + "_" + filename;
                    System.IO.File.Move(tmppath, path);

                    // add new paths to path list
                    this.Paths.Add(path);

                    stream.Close();
                    stream.Dispose();

                    _Face = System.Drawing.Image.FromFile(path);
                }
                catch (Exception)
                {
                    _Face = FaceCopy.Properties.Resources.CouldNotOpenImage;
                }
            }
        }

        private static string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                System.Security.Cryptography.SHA1Managed sha = new System.Security.Cryptography.SHA1Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        public FaceImage(String Category, String URL, String Path, String Name)
        {
            this.Category = Category;
            this.URL = URL;
            this.Paths = new List<String>();
            this.Paths.Add(Path);
            this.Name = Name;
        }

        public FaceImage(String Category, String URL, List<String> Paths, String Name)
        {
            this.Category = Category;
            this.URL = URL;
            this.Paths = Paths;
            this.Name = Name;
        }

        public override string ToString()
        {
            return "[" + this.Category + "] " + this.Paths.FirstOrDefault();
        }
    }
}
