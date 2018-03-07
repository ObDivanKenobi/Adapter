using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes
{
    public class PupilDataExporter
    {
        IDataWriter<Pupil> _writer;

        public PupilDataExporter(IDataWriter<Pupil> writer)
        {
            _writer = writer;
        }

        public void Export(ICollection<Pupil> pupils)
        {
            foreach (Pupil p in pupils)
                _writer.Write(p);
        }
    }
}
