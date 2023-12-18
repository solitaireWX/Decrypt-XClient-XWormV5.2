using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Security.Cryptography;

namespace Stub
{
    public class Zloy
    {
        public static void Main(string[] args)
        {
            DAPS();
        }

        public static void DAPS()
        {
            Settings.Hosts = Conversions.ToString(AlgorithmAES.Decrypt(Settings.Hosts));
            Settings.Port = Conversions.ToString(AlgorithmAES.Decrypt(Settings.Port));
            Settings.KEY = Conversions.ToString(AlgorithmAES.Decrypt(Settings.KEY));
            Settings.SPL = Conversions.ToString(AlgorithmAES.Decrypt(Settings.SPL));
            Settings.Groub = Conversions.ToString(AlgorithmAES.Decrypt(Settings.Groub));
            Settings.USBNM = Conversions.ToString(AlgorithmAES.Decrypt(Settings.USBNM));

            Console.WriteLine("Decrypted Settings:");
            Console.WriteLine("Hosts: " + Settings.Hosts);
            Console.WriteLine("Port: " + Settings.Port);
            Console.WriteLine("KEY: " + Settings.KEY);
            Console.WriteLine("SPL: " + Settings.SPL);
            Console.WriteLine("Groub: " + Settings.Groub);
            Console.WriteLine("USBNM: " + Settings.USBNM);
        }
    }



    // ?? Change
	public class Settings
	{
	  public static string Hosts = "WM9gIQ5UxNWMG2/B7vnS1A==";
	  public static string Host;
	  public static string Port = "MhnPw7FFFhzELqlXNj/5qA==";
	  public static string KEY = "/XUnWZUhuk2qHbeGFGE+Hg==";
	  public static string SPL = "otR4GvdeDl1AhTYM5SuH+Q==";
	  public static int Sleep = 3;
	  public static string Groub = "FZmY5LpdeIdpI7DzmC66GA==";
	  public static string USBNM = "Cou/N6h9a6BOy7TJfYCJPQ==";
	  public static string Mutex = "EkN0aEyQWiihdKnC";
	}


    // ?? ^^^^

    public class AlgorithmAES
    {
        public static object Decrypt(string input)
        {
            RijndaelManaged rM = new RijndaelManaged();
            MD5CryptoServiceProvider cP = new MD5CryptoServiceProvider();
            byte[] dA = new byte[32];
            byte[] h = cP.ComputeHash(Helper.S(Settings.Mutex));
            Array.Copy((Array)h, 0, (Array)dA, 0, 16);
            Array.Copy((Array)h, 0, (Array)dA, 15, 16);
            rM.Key = dA;
            rM.Mode = CipherMode.ECB;
            ICryptoTransform dcr = rM.CreateDecryptor();
            byte[] iB = Convert.FromBase64String(input);
            return Helper.B(dcr.TransformFinalBlock(iB, 0, iB.Length));
        }
    }

    public class Helper
    {
        public static byte[] S(string i)
        {
            return System.Text.Encoding.UTF8.GetBytes(i);
        }

        public static string B(byte[] i)
        {
            return System.Text.Encoding.UTF8.GetString(i);
        }
    }
}
