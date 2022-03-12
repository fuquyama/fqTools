using System;
using System.Text;

namespace fqTools
{
    public static class HexTools
    {
        public static byte[] HexString2ByteArray(string str, string delimiter = "", string prefix = "", string suffix = "")
        {
            string hexstr = str.Replace(" ", "").Replace("\t", "");
            if (delimiter.Length > 0)
            {
                hexstr = hexstr.Replace(delimiter, "");
            }
            if (prefix.Length>0)
            {
                hexstr = hexstr.Replace(prefix, "");
            }
            if (suffix.Length > 0)
            {
                hexstr = hexstr.Replace(suffix, "");
            }
            byte[] byteArray = new byte[hexstr.Length / 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hexstr.Substring(i * 2, 2), 16);
            }
            return byteArray;
        }


        public static string ByteArray2HexString(byte[] byteArray, string delimiter = "", string prefix = "", string suffix = "")
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++)
            {
                sb.Append(prefix + $"{byteArray[i]:X2}" + suffix + delimiter);
            }
            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
            return sb.ToString();
        }
    }
}