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
        public String Path;
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

        public String Category;

        private String _Filename = null;

        public System.Drawing.Image Face {
            get {
                if ( _Face == null ) LoadFace();
                return _Face;
            }
        }
        private System.Drawing.Image _Face = null;

        


        private void LoadFace() {
            if (Path != null)
            {
                try
                {
                    _Face = System.Drawing.Image.FromFile(Path);
                }
                catch (Exception)
                {
                    try
                    {
                        WebRequest req = WebRequest.Create(URL);
                        WebResponse response = req.GetResponse();
                        Stream stream = response.GetResponseStream();
                        _Face = System.Drawing.Image.FromStream(stream);
                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception)
                    {
                        _Face = FaceCopy.Properties.Resources.CouldNotOpenImage;
                    }
                }
            }
        }

        /*
        public FaceImage(String Category, String URL)
        {
            this.Category = Category;
            this.URL = URL;
            this.Path = null;
        }
        */
        public FaceImage(String Category, String URL, String Path)
        {
            this.Category = Category;
            this.URL = URL;
            this.Path = Path;
        }

        public override string ToString()
        {
            return "[" + this.Category + "] " + this.Path;
        }
    }
}
