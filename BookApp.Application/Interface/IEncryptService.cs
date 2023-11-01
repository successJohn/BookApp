using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
   public interface IEncryptService
    {
        public string Encrypt(string message);

        public string Decrypt(string cipherText);
    }
}

