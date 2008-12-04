using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using System.Windows.Forms;

namespace AYBABTU
{
    class Attachment
    {
        private string encodedFile = "";
        private string fileName = "";
        public byte[] decodedFile;

        public Attachment(string encoding, string name)
        {
            encodedFile = encoding;
            encodedFile = encodedFile.Replace("\n", "");
            fileName = name;
            decodedFile = Convert.FromBase64String(encodedFile);
            //MessageBox.Show(Convert.ToString(encodedFile.Length % 4));
        }

        public void writeFileToSystem(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            Stream bs = sw.BaseStream;

            byte[] b = decodedFile;

            bs.Write(b, 0, b.Length);

            sw.Close();
            sw = null;
        }
    }
}

