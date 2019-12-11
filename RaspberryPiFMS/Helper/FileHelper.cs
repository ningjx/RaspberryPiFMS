﻿using System.IO;
using System.Text;

namespace RaspberryPiFMS.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 覆写
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void Write(this string[] path, string data)
        {
            string pathStr = Path.Combine(path);
            string dicPath = Path.Combine(path.GetByCount(path.Length - 1));
            if (!Directory.Exists(dicPath))
                Directory.CreateDirectory(dicPath);
            using (FileStream fileStream = new FileStream(pathStr, FileMode.OpenOrCreate))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fileStream.Write(bytes);
            };
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Read(this string[] path)
        {
            string pathStr = Path.Combine(path);
            if (!File.Exists(pathStr))
                return string.Empty;
            using (FileStream fileStream = new FileStream(pathStr, FileMode.Open))
            {
                int length = (int)fileStream.Length;
                byte[] bytes = new byte[length];
                fileStream.Read(bytes, 0, bytes.Length);
                return Encoding.UTF8.GetString(bytes);
            };
        }
    }
}
