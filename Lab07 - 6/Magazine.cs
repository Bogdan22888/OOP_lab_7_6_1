using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Lab07___6
{
    public class Magazine : IComparable
    {
        public double width;
        public double height;
        public int pagesAmount;
        public int price;
        public int rating;

        public Magazine()
        {
            width = 0;
            height = 0;
            pagesAmount = 0;
            price = 0;
            rating = 0;
        }

        public Magazine(double w, double h, int pAm, int p, int r)
        {
            width = w;
            height = h;
            pagesAmount = pAm;
            price = p;
            rating = r;
        }

        int IComparable.CompareTo(object mag)
        {
            Magazine magazine = mag as Magazine;
            if (this.price < magazine.price)
                return -1;
            else if (this.price > magazine.price)
                return 1;
            else
                return 0;
        }

        public class SortByPagesAmount : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                Magazine magazine1 = obj1 as Magazine;
                Magazine magazine2 = obj2 as Magazine;
                if (magazine1.pagesAmount > magazine2.pagesAmount) return 1;
                else if (magazine1.pagesAmount < magazine2.pagesAmount) return -1;
                else return 0;
            }
        }

        public class SortByRating : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                Magazine magazine1 = obj1 as Magazine;
                Magazine magazine2 = obj2 as Magazine;
                if (magazine1.rating > magazine2.rating) return 1;
                else if (magazine1.rating < magazine2.rating) return -1;
                else return 0;
            }
        }
    }

    public class Magazines : IEnumerable
    {
        private Magazine[] magazines;
        private int size;

        public Magazines()
        {
            magazines = new Magazine[10];
            size = 0;
        }
        public Magazine[] GetArray() { return magazines; }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++) yield return magazines[i];
        }

        public void Add(Magazine m)
        {
            if (size >= 10) return;
            magazines[size] = m;
            size++;
        }

        public void ReadData(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            Magazine temp;
            string[] magInfo = new string[5];
            while (!reader.EndOfStream)
            {
                temp = new Magazine();
                magInfo = reader.ReadLine().Split(' ');
                try
                {
                    temp.height = Convert.ToDouble(magInfo[0]);
                    temp.width = Convert.ToDouble(magInfo[1]);
                    temp.pagesAmount = Convert.ToInt32(magInfo[2]);
                    temp.price = Convert.ToInt32(magInfo[3]);
                    temp.rating = Convert.ToInt32(magInfo[4]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("No, ne nado рассворачиватся");
                }
                Add(temp);
            }
        }
    }
}
