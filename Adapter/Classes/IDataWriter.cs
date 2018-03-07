using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes
{
    public interface IDataWriter<T>
    {
        string Path { get; }

        void Write(T data);
    }
}
