using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace DMessager.Utils
{
    public static class ResourcesManager
    {
        [SettingsBindable(true)]
        public static string ProjectName { get; set; } = "";
        public static string ResourcesDirectory { get; set; } = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;

        public static Bitmap getProjectImage(String file)
        {
            return Image.FromFile(
                ResourcesDirectory
                + "/" 
                + ProjectName 
                + file.Insert(0, "/Resources/")
            ) as Bitmap;
        }
    }
}