using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;


namespace Library.Tests
{
    [TestClass()]
    public class BookTests
    {

        [TestMethod()]
        public void SaveTest()
        {
            Book c1 = new Book("978-5-17-102028-6", "Сапковский Анджей", "Ведьмак: Последнее желание", "АСТ", "2021");
            globals.BookList.Add(c1);
            Book.Save();
            Assert.IsTrue(File.Exists(@"Books.xml"));
        }

        [TestMethod()]
        public void LoadTest()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("978-5-17-102028-6", "Сапковский Анджей", "Ведьмак: Последнее желание", "АСТ", "2021"));

            Book.Load();

            Assert.AreEqual(books.ToString(), globals.BookList.ToString());                  
        }
    }
}