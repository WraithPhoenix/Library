using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Main : Form
    {
        
        ViewBookList bookList = null;
        AddBook add = null;
       
        public Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void добавитьНовуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (add == null)
            {
                AddBook addBook = new AddBook();
                addBook.MdiParent = this;
                addBook.FormClosed += new FormClosedEventHandler(addBook_FormClosed);
                addBook.Show();
            }
        }

        void addBook_FormClosed(object sender, EventArgs e)
        {
            add = null;
            Book.Save();
           
        }

        private void посмотретьКнигиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookList == null)
            {
                ViewBookList ViewList = new ViewBookList();
                ViewList.MdiParent = this;
                ViewList.FormBorderStyle = FormBorderStyle.FixedDialog;
                ViewList.FormClosed += ViewList_FormClosed;
                ViewList.Show();
            }

        }

        private void ViewList_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookList = null;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Book.Save();

        }

     
        private void Main_Load(object sender, EventArgs e)
        { 
            Book.Load();
        }
       

    }
}