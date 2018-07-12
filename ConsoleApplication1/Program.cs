using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public struct Insan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public bool Askerlik { get; set; }

        public override string ToString()
        {
            return Ad + " " + Soyad;
        }
    }
    public static class ExtensionMethods
    {
        public static int Index<T>(this IEnumerable<T> veriler, string parametre)
        {
            int sonuc = -1, varmi = 0;
            foreach (T veri in veriler)
            {
                sonuc++;
                if (veri.ToString() == parametre) break;
                else { varmi++; }
            }
            if (varmi == veriler.Count()) { sonuc = -1; }
            return sonuc;
        }

        // Lambda Expressions ile sorgulama yapılabilen ve sonuçta veriler elde edilen metot
        public static IEnumerable<T> BulGetir<T>(this IEnumerable<T> veriler, Func<T, bool> expressions)
        {
            List<T> sonuc = new List<T>();
            foreach (T veri in veriler)
            {
                if (expressions(veri))
                {
                    sonuc.Add(veri);
                }
            }
            return sonuc;
        }
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }
    }
    class Program
    {
        static List<Insan> insanlar = new List<Insan>
        {
            new Insan { Ad="Test1",Askerlik=true,Soyad="Test1",Yas=20},
            new Insan { Ad="Test2",Askerlik=false,Soyad="Test2",Yas=21},
            new Insan { Ad="Test3",Askerlik=true,Soyad="Test3",Yas=22},
            new Insan { Ad="Test4",Askerlik=false,Soyad="Test4",Yas=23},
            new Insan { Ad="Test5",Askerlik=true,Soyad="Test5",Yas=24},
            new Insan { Ad="Test6",Askerlik=false,Soyad="Test6",Yas=25},
            new Insan { Ad="Test7",Askerlik=true,Soyad="Test7",Yas=26},
            new Insan { Ad="Test8",Askerlik=false,Soyad="Test8",Yas=27}
        };
        public static void insanyazdir(IEnumerable<Insan> list)
        {
            int count = 0;
            string yapildiMi;
            foreach (var item in list)
            {
                count++;
                yapildiMi = item.Askerlik ? "Yapıldı" : "Yapılmadı";
                Console.WriteLine($"{count}. Ad={item.Ad} Soyad={item.Soyad} Yas={item.Yas} Askerlik={yapildiMi}");
            }

        }
        static void Main(string[] args)
        {
            var askerlikyapanlar = insanlar.BulGetir(i => i.Askerlik == true);
            var sayi = askerlikyapanlar.Count();
            Func<int, int> square = x => x * x;//ilk int input olarak ikincisi out olarak belirtiyoruz
            Func<int, bool> isEqualThree = x => x == 3;//inlik int input bool dışarı vereceği değer
            Func<int, int, int> addProcess = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine($"Girmiş olduğunuz sayı{x}");
            write(3);
            Console.WriteLine(square(3));
            Console.WriteLine($"3 is equal 3:{isEqualThree(3)}");
            Console.WriteLine($"4 is equal 3:{isEqualThree(4)}");
            //Simdi farklı sekilde askerlik yapanları bulacağız ve yasa göre(küçükten büyüğe) sıralayacağız
            Func<bool, bool> isDoneMilitaryService = x => x == true;
            askerlikyapanlar = insanlar.Where(x => isDoneMilitaryService(x.Askerlik)).OrderBy(z => z.Yas);
            sayi = askerlikyapanlar.Count();
            Console.WriteLine("Askerlik yapanlar yas sıralı");
            insanyazdir(askerlikyapanlar);
            //
            askerlikyapanlar.Where(i => i.Askerlik == false);
            DateTime date = new DateTime(2002, 5, 5);
            var result = date.DaysToEndOfMonth();
            //A a;
            A b;
            A c;
            //a = new A();
            b = new B();
            c = new C();
            // a.yazdir("isim");
            b.yazdir("isim");
            c.yazdir("isim");
            Hesaplama del = Fiyat;
            Console.WriteLine($"KDV Hariç 5 Ürün Fiyatı: {del(5)}");
            del = KDVFiyat;  //delegate değiştiriliyor
            Console.WriteLine($"KDV Dahil 5 Ürün Fiyatı: {del(5)}");
            Console.WriteLine(SonucHesapla(5, Fiyat));
            Console.WriteLine(SonucHesapla(5, KDVFiyat));
            Console.ReadKey();
        }
        public delegate decimal Hesaplama(int sayi);
        public static decimal SonucHesapla(int sayi, Hesaplama hesapla)
        {
            return hesapla(sayi);
        }
        static decimal Fiyat(int sayi)
        {

            return sayi * 10.5m;
        }
        static decimal KDVFiyat(int sayi)
        {

            decimal kdvharicfiyat = sayi * 10.5m;
            //KDV %18 düşünüldü
            return kdvharicfiyat + kdvharicfiyat * 0.18m;
        }
    }
}
