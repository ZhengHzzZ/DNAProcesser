using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNAProcesser.ConvertImage
{
    class Invert
    {
        public static void InvertColor(string filePath, string outputPath)
        {
            Bitmap bmp = new Bitmap(filePath);
            // Lock the bitmap's bits.  锁定位图
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                //bmp.PixelFormat);
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Get the address of the first line.获取首行地址
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.定义数组保存位图
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.复制RGB值到数组
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            //Invert
            for (int counter = 0; counter < rgbValues.Length; counter += 4)
            {
                rgbValues[counter] = (byte)(255 - rgbValues[counter]);
                rgbValues[counter + 1] = (byte)(255 - rgbValues[counter + 1]);
                rgbValues[counter + 2] = (byte)(255 - rgbValues[counter + 2]);
            }

            // Copy the RGB values back to the bitmap 把RGB值拷回位图
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.解锁
            bmp.UnlockBits(bmpData);

            //Save
            bmp.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
