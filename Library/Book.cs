using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    public class Book
    {
        public string isbn;
        public string author;
        public string title;
        public string publish;
        public string year;
        public string create;

        public Book() { }
        public Book(string isbn, string author, string title, string publish, string year)
        {
            this.isbn = isbn;
            this.author = author;
            this.title = title;
            this.publish = publish;
            this.year = year;
            this.create = DateTime.Now.ToShortDateString();
        }


        /// <summary>
        /// Сохранение Изменений в списке книг
        /// </summary>
        public static void Save()
        {
            globals.BookList.Sort(new AuthorComparer());
            string filename = @"Books.xml";
            string filename1 = @"Books.txt";
            string string1 = string.Empty;

            XmlSerializer serializer = new XmlSerializer(globals.BookList.GetType());

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, globals.BookList);
                
                fs.Close();
            }        
            
            
            foreach (Book book in globals.BookList)
            {
                string1 += book.isbn + " " + book.author + " " + book.title + " " + book.publish + " " + book.year + " " + book.create + "\n";
            }

            File.WriteAllText(filename1, string1);

        }
     
        /// <summary>
        /// Загрузка изменений из файла
        /// </summary>
        public static void Load()
        {
            string filename = @"Books.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    globals.BookList = (List<Book>)serializer.Deserialize(fs);
                    fs.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }
        
    }

    class TitleComparer : IComparer<Book>
    {
        public Book Book
        {
            get => default;
            set
            {
            }
        }

        public int Compare(Book x, Book y)
        {
            return String.Compare(x.title, y.title);
        }

    }
    class AuthorComparer : IComparer<Book>
    {
        public Book Book
        {
            get => default;
            set
            {
            }
        }

        public int Compare(Book x, Book y)
        {
            return String.Compare(x.author, y.author);
        }

    }
    class PubComparer : IComparer<Book>
    {
        public Book Book
        {
            get => default;
            set
            {
            }
        }

        public int Compare(Book x, Book y)
        {
            return String.Compare(x.publish, y.publish);
        }

    }
    class CreateComparer : IComparer<Book>
    {
        public Book Book
        {
            get => default;
            set
            {
            }
        }

        public int Compare(Book x, Book y)
        {
            return String.Compare(x.create, y.create);
        }

    }
}
