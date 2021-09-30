using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CA210930_2
{
    class Felhasznalo
    {
        private byte[] _jelszoHash; 
        public string FelhasznaloiNev { get; set; }

        public bool JelszoEllenorzeses(byte[] kapott)
        {
            return Enumerable.SequenceEqual(kapott, _jelszoHash);
        }

        public void JelszoMegvaltoztatas(byte[] newHash)
        {
            _jelszoHash = newHash;
        }

    }


    class Program
    {
        static void Main()
        {
            var f = new Felhasznalo()
            {
                FelhasznaloiNev = "geza",
            };

            Console.Write("add meg a jelszót: ");
            byte[] hash = GetHash(Console.ReadLine());

            f.JelszoMegvaltoztatas(hash);

            Console.Clear();

            Console.Write("belépéshez írd be a jelszót: ");

            if(f.JelszoEllenorzeses(GetHash(Console.ReadLine())))
            {
                Console.WriteLine("SIKER");
            }
            else Console.WriteLine("NOPE!");

            Console.ReadKey();

        }

        private static byte[] GetHash(string source)
        {
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                return md5Hash.ComputeHash(sourceBytes);
            }
            //var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }
}
