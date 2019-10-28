using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace WebScrapping
{
    public class Scrapping
    {
        private const string url1 = "https://news.am/arm/rss/";
        private const string url2 = "https://www.vesti.ru/vesti.rss";
        private const string url3 = "https://www.mk.ru/rss/news/index.xml";

        public static async Task<string> GetData()
        {
            string response = String.Empty;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage sendQuery = await client.GetAsync(url1);
                response = await sendQuery.Content.ReadAsStringAsync();
            }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(response);

            XmlElement xRoot = xDoc.DocumentElement;
            
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - company
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Компания: {childnode.InnerText}");
                    }
                    // если узел age
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }
                }
            }
        }
    }
}
