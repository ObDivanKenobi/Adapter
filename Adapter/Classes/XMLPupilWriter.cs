using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adapter.Classes
{
    public class XmlPupilWriter : IDataWriter<Pupil>
    {
        private string _path;
        public string Path => _path;

        public XmlPupilWriter(string path)
        {
            _path = path;
        }

        public void Write(Pupil pupil)
        {
            if (!File.Exists(_path))
                CreateNewFile();

            XmlDocument document = new XmlDocument();
            document.Load(_path);

            XmlNode pupilElement = document.CreateElement("pupil");
            document.DocumentElement.AppendChild(pupilElement);

            XmlNode fieldNode = document.CreateElement("name");
            fieldNode.InnerText = pupil.Name;
            pupilElement.AppendChild(fieldNode);

            fieldNode = document.CreateElement("school");
            fieldNode.InnerText = pupil.School;
            pupilElement.AppendChild(fieldNode);

            fieldNode = document.CreateElement("pupils-form");
            XmlAttribute attribute = document.CreateAttribute("form");
            attribute.Value = $"{pupil.Form}";
            fieldNode.Attributes.Append(attribute);

            if (pupil.Litera != null)
            {
                attribute = document.CreateAttribute("litera");
                attribute.Value = $"{pupil.Litera}";
                fieldNode.Attributes.Append(attribute);
            }
            pupilElement.AppendChild(fieldNode);

            fieldNode = document.CreateElement("grades");
            foreach (var line in pupil.Grades)
            {
                XmlNode gradesNode = document.CreateElement("subject");
                attribute = document.CreateAttribute("name");
                attribute.Value = line.Key;
                gradesNode.Attributes.Append(attribute);

                foreach (var grade in line.Value)
                {
                    XmlNode gradeNode = document.CreateElement("grade");
                    gradeNode.InnerText = $"{grade}";
                    gradesNode.AppendChild(gradeNode);
                }
                pupilElement.AppendChild(gradesNode);
            }

            document.Save(_path);
        }

        private void CreateNewFile()
        {
            XmlTextWriter writer = new XmlTextWriter(_path, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("body");
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
