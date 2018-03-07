using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adapter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes.Tests
{
    [TestClass()]
    public class XmlPupilWriterTests
    {
        [TestMethod()]
        public void WriteTest()
        {
            string path = "tmp.xml";
            XmlPupilWriter writer = new XmlPupilWriter(path);

            Pupil[] data = new[]
            {
                new Pupil()
                {
                    Name = "Иванов Иван Иванович",
                    School = "Школа №2",
                    Form = 4,
                    Litera = 'А',
                    Grades = new Dictionary<string, List<uint>>
                    {
                        { "Русский язык", new List<uint> { 4, 4, 5, 4 } },
                        { "Литература", new List<uint> { 4, 4, 3 } },
                        { "Математика", new List<uint> { 5, 5 } }
                    }
                },
                new Pupil()
                {
                    Name = "Сидоров Сидор Сидорович",
                    School = "Школа №1 г. Припять им. Меченого",
                    Form = 11,
                    Litera = null,
                    Grades = new Dictionary<string, List<uint>>
                    {
                        { "Экономика", new List<uint> { 5, 5, 5, 5 } },
                        { "Физическая культура", new List<uint> { 2, 2 } },
                        { "Культура речи", new List<uint> { 2, 3, 2 } }
                    }
                }
            };

            writer.Write(data[1]);
        }
    }
}