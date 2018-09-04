using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Currencies
{
    public class Bank
    {
        public string Buy { get; set; }
        public string Sale { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            string str = string.Format(">>Name of bank: {0}\n" +
                "Order: {1}\n" +
                "Sale: {2}\n\n", Name, Buy, Sale);
            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            bool inProgress = true;

            while (inProgress)
            {
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("" +
                    "1)Task 1 \n" +
                    "2)Task 2 \n" +
                    "3)Exit \n");
                Console.WriteLine(new string('-', 80));
                Console.Write("> ");

                int ch = 0;
                Int32.TryParse(Console.ReadLine(), out ch);

                switch (ch)
                {
                    case 1:
                        {
                            Task1();
                        }
                        break;
                    case 2:
                        {
                            Task2();
                        }
                        break;
                    case 3:
                        {
                            inProgress = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Retry...");
                        break;
                }
            }
        }

        static void Task1()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Currency.xml");

            XmlElement xRoot = doc.DocumentElement;
            List<Bank> banks = new List<Bank>();

            foreach (XmlNode item in xRoot)
            {
                Bank bank = new Bank();
                if (item.Attributes.Count > 0)
                {
                    XmlNode attr = item.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        bank.Name = attr.Value;
                    }
                }
                foreach (XmlNode child in item.ChildNodes)
                {
                    if (child.Name == "buy")
                    {
                        bank.Buy = child.InnerText;
                    }
                    if (child.Name == "sale")
                    {
                        bank.Sale = child.InnerText;
                    }
                }
                banks.Add(bank);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("\t\tCurrencies");
            Console.WriteLine(new string('-', 50));

            foreach (Bank item in banks)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Data has been saved into file CurrencySave.xml");
            Console.WriteLine(new string('-', 50));
            doc.Save("CurrencySave.xml");

        }

        static void Task2()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Goods.xml");

            XmlElement xRoot = doc.DocumentElement;

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Original file: ");
            Console.WriteLine(new string('-', 50));

            foreach (XmlNode item in xRoot)
            {
                if (item.Attributes.Count > 0)
                {
                    XmlNode attr = item.Attributes.GetNamedItem("id");
                    if (attr != null)
                    {
                        Console.WriteLine("Order #{0}:", attr.Value);
                    }
                }
                foreach (XmlNode child in item.ChildNodes)
                {
                    if (child.Name == "commodity")
                    {
                        Console.WriteLine("Commodity {0}:", child.InnerText);
                    }
                }

                Console.WriteLine();
            }

            XmlElement orderElem = doc.CreateElement("order");

            XmlAttribute idOrderAttr = doc.CreateAttribute("id");

            XmlElement commElem1 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr1 = doc.CreateAttribute("id");
            XmlElement commElem2 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr2 = doc.CreateAttribute("id");
            XmlElement commElem3 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr3 = doc.CreateAttribute("id");
            XmlElement commElem4 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr4 = doc.CreateAttribute("id");
            XmlElement commElem5 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr5 = doc.CreateAttribute("id");

            XmlText idOrderAttrText = doc.CreateTextNode("5");

            XmlText commElem1Text = doc.CreateTextNode("commodity 1");
            XmlText idCommAttr1Text = doc.CreateTextNode("1");
            XmlText commElem2Text = doc.CreateTextNode("commodity 2");
            XmlText idCommAttr2Text = doc.CreateTextNode("2");
            XmlText commElem3Text = doc.CreateTextNode("commodity 3");
            XmlText idCommAttr3Text = doc.CreateTextNode("3");
            XmlText commElem4Text = doc.CreateTextNode("commodity 4");
            XmlText idCommAttr4Text = doc.CreateTextNode("4");
            XmlText commElem5Text = doc.CreateTextNode("commodity 5");
            XmlText idCommAttr5Text = doc.CreateTextNode("5");

            idOrderAttr.AppendChild(idOrderAttrText);

            commElem1.AppendChild(commElem1Text);
            idCommAttr1.AppendChild(idCommAttr1Text);
            commElem2.AppendChild(commElem2Text);
            idCommAttr2.AppendChild(idCommAttr2Text);
            commElem3.AppendChild(commElem3Text);
            idCommAttr3.AppendChild(idCommAttr3Text);
            commElem4.AppendChild(commElem4Text);
            idCommAttr4.AppendChild(idCommAttr4Text);
            commElem5.AppendChild(commElem5Text);
            idCommAttr5.AppendChild(idCommAttr5Text);

            orderElem.Attributes.Append(idOrderAttr);

            orderElem.AppendChild(commElem1);
            orderElem.Attributes.Append(idCommAttr1);
            orderElem.AppendChild(commElem2);
            orderElem.Attributes.Append(idCommAttr2);
            orderElem.AppendChild(commElem3);
            orderElem.Attributes.Append(idCommAttr3);
            orderElem.AppendChild(commElem4);
            orderElem.Attributes.Append(idCommAttr4);
            orderElem.AppendChild(commElem5);
            orderElem.Attributes.Append(idCommAttr5);

            xRoot.AppendChild(orderElem);

            doc.Save("Goods.xml");

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("File after edition: ");
            Console.WriteLine(new string('-', 50));

            foreach (XmlNode item in xRoot)
            {
                if (item.Attributes.Count > 0)
                {
                    XmlNode attr = item.Attributes.GetNamedItem("id");
                    if (attr != null)
                    {
                        Console.WriteLine("Order #{0}:", attr.Value);
                    }
                }
                foreach (XmlNode child in item.ChildNodes)
                {
                    if (child.Name == "commodity")
                    {
                        Console.WriteLine("Commodity {0}:", child.InnerText);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}