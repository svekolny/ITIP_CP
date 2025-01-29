using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable SYSLIB0011

namespace ITIP_1
{
    public interface IForKurs
    {
        List<Func<string>> GenerateDelegateList();

        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }
    }
}
