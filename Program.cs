using System;

namespace LibraryEx
{
    class LibItem
    {
        public int GetRecomendations() { return 0;  }
    }
    class Book:LibItem
    {

    }

    class EduBook:Book { }
    class EduSoft:LibItem { }
    interface IEdu
    {
        string GetSubject();
        bool IsApproved();
    }

    class Library
    {
        private LibItem[] items;
        private int numItems;
        private const int MAXITEMS = 1000;
        public Library()
        {
            this.items = new LibItem[MAXITEMS];
            this.numItems = 0;
        }

        public Book [] GetPopularBooks(int min)
        {
            //First count how many books are popuar
            int count = 0;
            for (int i = 0; i < this.numItems; i++)
            {
                if (items[i] is Book)
                {
                    Book b = (Book)items[i];
                    if (b.GetRecomendations() > min)
                        count++;
                }
            }
            //Create popular books array with the proper size.
            Book[] arr = new Book[count];
            //Search and fill the popular books in the array
            int j = 0;
            for (int i = 0; i < this.numItems; i++)
            {
                if (items[i] is Book)
                {
                    Book b = (Book)items[i];
                    if (b.GetRecomendations() > min)
                    {
                        arr[j] = b;
                        j++;
                    }
                }
            }
            return arr;
        }

        public IEdu[] GetApprovedEduItems(string subject)
        {
            //First count how many Edu items are approved 
            int count = 0;
            for (int i = 0; i < this.numItems; i++)
            {
                if (items[i] is IEdu)
                {
                    IEdu item = (IEdu)items[i];
                    if (item.GetSubject() == subject && item.IsApproved())
                        count++;
                }
                    
            }
            //Create array with the proper size.
            IEdu[] arr = new IEdu[count];
            //Search and fill the approved Edu items in the array
            int j = 0;
            for (int i = 0; i < this.numItems; i++)
            {
                if (items[i] is IEdu)
                {
                    IEdu item = (IEdu)items[i];
                    if (item.GetSubject() == subject && item.IsApproved())
                    {
                        arr[j] = item;
                        j++;

                    }
                }
            }
            return arr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
