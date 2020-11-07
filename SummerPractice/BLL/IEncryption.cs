using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IEncryption : IRepository
    {
        string GetHash(string plaintext);
        bool CompareHash(string basePassword, string password);
    }
}
