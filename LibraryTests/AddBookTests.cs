using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    [TestClass()]
    public class AddBookTests
    {
        [TestMethod()]
        public void AddBookTest()
        {
            Book c1 = new Book("978-5-17-102028-6", "Сапковский Анджей", "Ведьмак: Последнее желание", "АСТ", "2021");
            globals.BookList.Add(c1);
            Book.Save();

            Assert.IsTrue(globals.BookList.Contains(c1));
        }
    }
}