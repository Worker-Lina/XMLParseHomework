using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLPathHomework
{
    class Program
    {
        public static readonly int ROUTE_ELEMENT_POSITION = 0;

        static void Main(string[] args)
        {
            var list = new List<Item>();

            var xmlDocument = new XmlDocument();
            xmlDocument.Load("https://habrahabr.ru/rss/interesting/");

            XmlElement xRoot = xmlDocument.DocumentElement;

            foreach (XmlElement xnode in xRoot)
            {
                var item = new Item();
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "title":
                            item.Title = childnode.InnerText;
                            break;
                        case "link":
                            item.Link = childnode.InnerText;
                            break;
                        case "description":
                            item.Description = childnode.InnerText;
                            break;
                        case "pubDate":
                            item.PubDate = childnode.InnerText;
                            break;
                    }
                }
                list.Add(item);
            }
            foreach (var item in list)
                Console.WriteLine($"{item.Title} ({item.Link}) - {item.Description} - {item.PubDate}");
            Console.Read();
            Console.Clear();




            // 2 задание

            /*var studentList = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alina",
                    Surname = "Chelovechkova",
                    Age = 19,
                    Group ="Sep-201",
                    Rating = 10.9
                },
                new Student
                {
                    Id = 2,
                    Name = "Kamila",
                    Surname = "Evgnat",
                    Age = 19,
                    Group ="Sep-201",
                    Rating = 11.5
                },
                new Student
                {
                    Id =3,
                    Name = "Damir",
                    Surname = "Daryn",
                    Age = 19,
                    Group ="Sep-201",
                    Rating = 9.8
                }
            };


            var xmlDocument = new XmlDocument();
            var xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            xmlDocument.AppendChild(xmlDeclaration);

            var routeElement = xmlDocument.CreateElement("studentList");
            xmlDocument.AppendChild(routeElement);

            foreach(var student in studentList)
            {
                var studentElement = xmlDocument.CreateElement("student");
                studentElement.SetAttribute("id", student.Id.ToString());
                studentElement.SetAttribute("name", student.Name);
                studentElement.SetAttribute("surname", student.Surname);
                studentElement.SetAttribute("age", student.Age.ToString());
                studentElement.SetAttribute("group", student.Group);
                studentElement.SetAttribute("rating", student.Rating.ToString());

                routeElement.AppendChild(studentElement);
            }
            xmlDocument.Save("studentData.xml");*/

        }
    }
}
