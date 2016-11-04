using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShopThreeLayer.Infastructure
{
    public class LocalUploader
    {
        public  string SaveImage(HttpPostedFileBase file, string name,string path)
        {
            Bitmap bitmap = new Bitmap(new Bitmap(file.InputStream), 350, 260);
            bitmap.Save(path, ImageFormat.Jpeg);

            string paht = "~/Image/" + name.Replace(" ", "") + ".jpg";

            return paht;


        }
    }
}