using System;
using System.IO;
using UserInterface1;

namespace MainMenu
{
    public class MainScreen
    {








        public void ControlFile(string path, string filename)
        {

            System.IO.FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            if (fileStream != null)
            {
                Console.Write("dosya açıldı");
            }

            fileStream.Close();

        }


        public void AddBorrow(int Id, string Name, string ReturnDate, string Date, string path)
        {
            BookFeature book = new BookFeature();


            book.Id = Id;
            book.Name = Name;
            book.ReturnDate = ReturnDate;
            book.Date = Date;


            byte[] bookByte = BookFeature.BookToByteArrayBlockBorrow(book);
            FileOperations.AppendBlock(bookByte, path);

            Console.SetCursorPosition(57, 8);
            Console.Write("**Yazma Başarılı**");

        }
        public void AddBook(int Id, string Title, string Description, string Authors, string Categories, string path)
        {
            BookFeature book1 = new BookFeature();


            book1.Id = Id;
            book1.Title = Title;
            book1.Description = Description;
            book1.Authors = Authors;
            book1.Categories = Categories;








            byte[] bookBytes1 = BookFeature.BookToByteArrayBlock(book1);
            FileOperations.AppendBlock(bookBytes1, path);
            //FileOperations.DeleteBlock();




            Console.Clear();
            GUI.userint(40, 90, 2, 27);
            GUI.userint(40, 90, 2, 27);


            Console.SetCursorPosition(50, 8);
            Console.Write("**Yazma Başarılı**");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Kitap Numarası:" + Id);
            Console.SetCursorPosition(50, 11);
            Console.WriteLine("Kitap İsmi:" + Title);
            Console.SetCursorPosition(50, 12);
            Console.WriteLine("Kitap Tanımı:" + Description);
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Kitap Yazarı:" + Authors);
            Console.SetCursorPosition(50, 14);
            Console.WriteLine("Kitap Kategorisi:" + Categories);

            System.Threading.Thread.Sleep(2000);

        }


        public int IncreaseBook(int amount)
        {
            //int Id, string path
            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");
            //BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBookCounter(bookWrittenBytes);
            BookFeature book = new BookFeature();

            //int index = 0;
            //byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            //Array.Copy(bookWrittenBytes, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(bookWrittenBytes);
            //index += BookFeature.ID_LENGTH;
            //Console.WriteLine(book.Id);
            amount = book.Id + amount;
            //Console.WriteLine(book.Id);
            bookWrittenBytes = DataOperations.IntegerToByteArray(amount);
            FileOperations.DeleteBlock(1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");
            FileOperations.UpdateBlock(bookWrittenBytes, 1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");

            return amount;

            /*
            BookFeature book1 = new BookFeature();


            book1.Id = Id;
           
            byte[] bookBytes1 = BookFeature.BookToByteArrayBlock(book1);

            //FileOperations.DeleteBlock();
            FileOperations.AppendBlock(bookBytes1, path);

            Console.Clear();
            GUI.userint(40, 90, 2, 27);
            GUI.userint(40, 90, 2, 27);


            Console.SetCursorPosition(50, 8);
            Console.Write("**Artırma Başarılı**");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Toplam Kitap Sayısı" + Id);
           
            */


        }
        public int DecreaseBook(int amount)
        {

            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");
            //BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBookCounter(bookWrittenBytes);
            BookFeature book = new BookFeature();

            //int index = 0;
            //byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            //Array.Copy(bookWrittenBytes, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(bookWrittenBytes);
            //index += BookFeature.ID_LENGTH;
            if (book.Id == 0) { Console.Write("Kitap sayısı zaten 0"); return amount; }
            amount = book.Id - amount;
            //Console.WriteLine(book.Id);
            bookWrittenBytes = DataOperations.IntegerToByteArray(amount);
            FileOperations.DeleteBlock(1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");
            FileOperations.UpdateBlock(bookWrittenBytes, 1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");

            return amount;

        }
        public int BookCount()
        {
            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, 4, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/BookCount.dat");
            BookFeature book = new BookFeature();

            book.Id = DataOperations.ByteArrayToInteger(bookWrittenBytes);
            Console.WriteLine(book.Id);
            return book.Id;
        }
        /*
        public void AddBook2(int Id, string Title, string Description, string Authors, string Categories)
        {
            BookFeature book2 = new BookFeature();


            book2.Id = Id;
            //book1.Title = Title;
            book2.Description = Description;
            book2.Authors = Authors;
            book2.Categories = Categories;







            byte[] bookBytes2 = BookFeature.BookToByteArrayBlock(book2);

            
            FileOperations.AppendBlock2(bookBytes2, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/Library.dat");

            Console.Clear();
            GUI.userint(40, 90, 2, 27);
            Console.SetCursorPosition(50, 8);
            Console.Write("**Yazma Başarılı**");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Kitap Numarası:" + Id);
            Console.SetCursorPosition(50, 11);
            Console.WriteLine("Kitap İsmi:" + Title);
            Console.SetCursorPosition(50, 12);
            Console.WriteLine("Kitap Tanımı:" + Description);
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Kitap Yazarı:" + Authors);
            Console.SetCursorPosition(50, 14);
            Console.WriteLine("Kitap Kategorisi:" + Categories);

            System.Threading.Thread.Sleep(1000);




        }
        */
        /*
        public void AddBook3(int Id, string Title, string Description, string Authors, string Categories)
        {
            BookFeature book3 = new BookFeature();


            book3.Id = Id;
            //book1.Title = Title;
            book3.Description = Description;
            book3.Authors = Authors;
            book3.Categories = Categories;







            byte[] bookBytes3 = BookFeature.BookToByteArrayBlock(book1);

            //FileOperations.DeleteBlock();
            FileOperations.AppendBlock(bookBytes3, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/Library.dat");






        }
        public void AddBook3(int Id, string Title, string Description, string Authors, string Categories)
        {
            BookFeature book1 = new BookFeature();


            book1.Id = Id;
            //book1.Title = Title;
            book1.Description = Description;
            book1.Authors = Authors;
            book1.Categories = Categories;







            byte[] bookBytes1 = BookFeature.BookToByteArrayBlock(book1);

            //FileOperations.DeleteBlock();
            FileOperations.AppendBlock(bookBytes1, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/Library.dat");






        }
        */
        public void PullBorrow()
        {

            byte[] borrowWrittenBytes = FileOperations.ReadBlock(1, BookFeature.Borrow_Data_Block_Size, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/Borrow.dat");
            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBorrow(borrowWrittenBytes);

            //Console.WriteLine(bookWrittenObject);
        }
        public void PullBook()
        {

            //BookFeature book1 = new BookFeature();

            //byte[] bookBytes1 = BookFeature.BookToByteArrayBlock(book1);
            //BookFeature book2Object = BookFeature.ByteArrayBlockToBook(bookBytes1);
            //Console.Write(book2Object.ToString());

            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/Library.dat");
            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
            //Console.Clear();
            //GUI a = new GUI();
            //a.userint(40, 90, 2, 27);
            //Console.SetCursorPosition(44, 5);

            //BookFeature book2Object = BookFeature.ByteArrayBlockToBook(bookBytes1);


        }


        /*
        #region Get Executable Running Path and Set Library.Dat File Path to This Location
        string path = "C:/Users/Süleyman Mert/Desktop/ConsoleApp1/ConsoleApp1";
        string filename = Path.Combine(path, "LibraryData.dat");
        #endregion

        #region Testing Purpose Delete Library.Dat File If Exist
        FileOperations.DeleteFile(filename);
        #endregion

        #region Generate Book1 Object
        BookFeature book1 = new BookFeature();
        book1.Id = 5;
        book1.Title = "Demo Title 1";
        book1.Description = "Demo Description 1";
        book1.Authors.Add("Demo Author 1");
        book1.Authors.Add("Demo Author 2");
        book1.Categories.Add("ScienceFiction");
        book1.Categories.Add("Drama");
        #endregion
        */

        /*
        #region Generate Book2 Object
        BookFeature book2 = new BookFeature();   
            book2.Id = 6;
            book2.Title = "Demo Title 2";
            book2.Description = "Demo Description 2";
            book2.Authors.Add("Demo Author 3");
            book2.Authors.Add("Demo Author 4");
            book2.Categories.Add("ScienceFiction");
            book2.Categories.Add("Drama");
            BookFeature book3 = new BookFeature();
            #endregion

            #region Generate Book3 Object
            book3.Id = 7;
            book3.Title = "Demo Title 3";
            book3.Description = "Demo Description 3";
            book3.Authors.Add("Demo Author 5");
            book3.Authors.Add("Demo Author 6");
            book3.Categories.Add("ScienceFiction");
            book3.Categories.Add("Drama");
            #endregion

            #region Convert Book Objects to Byte Arrays
            byte[] bookBytes1 = BookFeature.BookToByteArrayBlock(book1);
            byte[] bookBytes2 = BookFeature.BookToByteArrayBlock(book2);
            byte[] bookBytes3 = BookFeature.BookToByteArrayBlock(book3);
            #endregion

            #region Testing Purpose Convert First Book Bytes to Hex for Test Function
            //string bookBytesHex = ConversionUtility.ToHex(bookBytes1);
            #endregion

            #region Append Book1-2-3 to File
            FileOperations.AppendBlock(bookBytes1, filename);
            FileOperations.AppendBlock(bookBytes2, filename);
            FileOperations.AppendBlock(bookBytes3, filename);
            #endregion

            #region Read Second Book Record and Convert Byte to Book Object
            byte[] bookWrittenBytes = FileOperations.ReadBlock(2, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
            #endregion

            #region Delete Second Book Record and Check it Deleted
            FileOperations.DeleteBlock(2, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            bookWrittenBytes = FileOperations.ReadBlock(2, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
            //Book 2 object will be null
            #endregion

            #region Update Deleted Book 2 Record with Book 1 Data and Read Record for Test
            FileOperations.UpdateBlock(bookBytes1, 2, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            bookWrittenBytes = FileOperations.ReadBlock(2, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
            #endregion

            #region Update Book 3 Record with Book 2 and Read Data for Test
            FileOperations.UpdateBlock(bookBytes2, 3, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            bookWrittenBytes = FileOperations.ReadBlock(3, BookFeature.BOOK_DATA_BLOCK_SIZE, filename);
            bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
            #endregion

            #region Convert byte block to book object
            BookFeature book2Object = BookFeature.ByteArrayBlockToBook(bookBytes2);
            #endregion

        
        
        }*/

    }
}
