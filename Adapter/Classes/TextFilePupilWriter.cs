using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes
{
    class TextFilePupilWriter : IDataWriter<Pupil>
    {
        private string _path;
        public string Path => _path;

        public TextFilePupilWriter(string path)
        {
            _path = path;
        }

        public void Write(Pupil pupil)
        {
            FileStream stream = new FileStream(Path, FileMode.Append, FileAccess.Write);
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(pupil.Name);
                writer.WriteLine($"Школа: {pupil.School}");
                writer.WriteLine($"Класс: {pupil.Form} {pupil.Litera??'\0'}");
                foreach (var line in pupil.Grades)
                {
                    writer.Write($"{line.Key}:");
                    foreach (var grade in line.Value)
                        writer.Write($" {grade}");
                    writer.WriteLine(";");
                }
            }
            stream.Close();
        }
    }
}
