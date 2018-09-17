
 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ACUManager
{
    class Common
    {
        public static byte[] GetAvatar(Image image, string Path)
        {
            byte[] arr = null;
            FileStream stream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader binary = new BinaryReader(stream);
            arr = binary.ReadBytes((int)stream.Length);
            return arr;
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            Image i2 = new Bitmap(120,135);
            Graphics gfxNewImage = Graphics.FromImage(i2);
            gfxNewImage.DrawImage(imageIn,new Rectangle(0, 0, i2.Width,i2.Height),0, 0,imageIn.Width, imageIn.Height,GraphicsUnit.Pixel);
            gfxNewImage.Dispose();
            imageIn.Dispose();
            i2.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static void GoBack(UserControl ucDes,UserControl ucSorce)
        {            
            Panel p = (ucSorce.Parent as Panel);
            p.Controls.Clear();
            p.Controls.Add(ucDes);
            ucDes.Dock = DockStyle.Fill;

        }
    }
}
