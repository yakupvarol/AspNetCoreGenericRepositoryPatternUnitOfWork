using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Helper
{
    public class LinqQuery
    {
        // https://csharp-tutorials.com/tr-TR/linq/Min

        /// <summary>
        /// Aggregation
        /// </summary>
        /// <param name="args"></param>
        /// 
        public static void LongCount(string[] args)
        {
            // Count() anahtar sözcüğü koleksiyonda bulunan verilerin sayısını verir.
            // Count anahtar sözcüğü bir koleksiyon içerisinde ki eleman sayısını verir. Dizideki eleman sayısını ekrana yazan program aşağıdaki gibidir.
            // Kod Çıktısı : 10
            var months = new List<string>
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };
            var result = months.LongCount();

            Console.WriteLine("Koleksiyon tipi: " + result.GetType().Name);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Sum(string[] args)
        {
            //Sum() anahtar sözcüğü koleksiyon içerisinde bulunan sayısal değerlerin toplanmasını sağlar.
            //Sum anahtar sözcüğü ile koleksiyonda bulunan sayı değerlerinin toplamını sağlayan metotdur.Dizide bulunan tamsayı değerlerinin toplamını ekrana yazan program aşağıdaki gibidir.
            //Kod Çıktısı : 244

            int[] numbers = { 10, 22, 5, 48, 4, 125, 1, 29 };

            var result = numbers.Sum();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Min(string[] args)
        {
            // Min() anahtar sözcüğü koleksiyon içerisinde bulunan sayısal değerlerin ün küçük olanını verir.
            // Min anahtar sözcüğü ile koleksiyonda bulunan sayı değerlerinin en küçük olan veriyi bulur. Dizide bulunan tamsayı değerlerinin en küçük olan değeri ekrana yazan program aşağıdaki gibidir.
            // Kod Çıktısı : 1
            int[] numbers = { 10, 22, 5, 48, 4, 125, 1, 29 };

            var result = numbers.Min();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Max(string[] args)
        {
            // Max() anahtar sözcüğü koleksiyon içerisinde bulunan sayısal verilerin en büyük değere sahip olan elementini döndürür.
            // Max anahtar sözcüğü ile koleksiyonda bulunan sayı değerlerinin en büyük olan veriyi bulur. Dizide bulunan tam sayı değerlerinin en büyük olan değeri ekrana yazan program aşağıdaki gibidir.
            // Kod Çıktısı :125

            int[] numbers = { 10, 22, 5, 48, 4, 125, 1, 29 };

            var result = numbers.Max();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Average(string[] args)
        {
            // Average() anahtar sözcüğü bir koleksiyonda bulunan sayısal değerlerin ortalamasını döndürür.
            // Average anahtar sözcüğü ile koleksiyonda bulunan sayı değerlerinin ortalamasını hesaplar. Dizide bulunan tamsayı değerlerinin ortalamasını ekrana yazan program aşağıdaki gibidir.
            // Kod Çıktısı :15

            int[] numbers = { 5, 10, 15, 20, 25 };
            var result = numbers.Average();

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Aggregate(string[] args)
        {
            // Aggregate() anahtar sözcüğü, koleksiyonda bulunan sayısal değerlere belirtilen  işleme göre hesaplanmasını sağlar. Toplama, çarpma vb. işlemler ile koleksiyonda bulunan bütün değerler aynı işleme tabi tutularak sonuç elde edilir.
            // Kod Çıktısı :24

            var numbers = new int[] { 1, 2, 3, 4 };
            var result = numbers.Aggregate((a, b) => a * b);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void LongCountBy(string[] args)
        {
            // LongCount() anahtar sözcüğü koleksiyonda bulunan öğe sayısını verir. Sonuç türü Int64 olarak döner. LongCount() anahtar sözcüğü koleksiyonda bulunan öğelerin sayısının Int32 den büyük olma ihtimali varsa kullanılmalıdır. Aksi taktirde Count() anahtar sözcüğü kullanmak daha doğru olacaktır.
            // Kod Çıktısı :Koleksiyon tipi: Int64 10

            var months = new List<string>
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };
            var result = months.LongCount();

            Console.WriteLine("Koleksiyon tipi: " + result.GetType().Name);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        /// <summary>
        /// Filtering
        /// </summary>
        /// <param name="args"></param>

        public static void Where(string[] args)
        {
            // Where() anahtar kelimesi sorgularda filtreleme için kullanılır. System.Linq kütüphanesinde bulunur. Gereric type özelliğine sahiptir. Koleksiyon öğelerini filtreleyen bir yöntemdir. Lambda ile yazılan Where() anahtar sözcüğü ile koleksiyondaki veriler filtrelenir.
            // Kod Çıktısı : Ürün Adı: Elma - Ürün Fiyatı: 4 Ürün Adı: Üzüm - Ürün Fiyatı: 7 Ürün Adı: Kiraz - Ürün Fiyatı: 9


            IList<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Süt",
                    CategoryName = "Gıda",
                    Price = 3
                },
                new Product
                {
                    Id = 2,
                    Name = "Elma",
                    CategoryName = "Meyve",
                    Price = 4
                },
                new Product
                {
                    Id = 2,
                    Name = "Üzüm",
                    CategoryName = "Meyve",
                    Price = 7
                },
                new Product
                {
                    Id = 2,
                    Name = "Kiraz",
                    CategoryName = "Meyve",
                    Price = 9
                }
            };

            
            var result = from p in products
                         where p.CategoryName == "Meyve"
                         select p;
            
            /*
            var result = from p in products
                         where p.Price > 3 && p.CategoryName == "Meyve"
                         select p.Name;

            foreach (var product in result)
            {
                Console.WriteLine("Ürün Adı: " + product.Name + " - Ürün Fiyatı: " + product.Price);
            }
            */

            Console.ReadLine();

        }

        public static void OfType(string[] args)
        {
            // OfType() anahtar sözcüğü özel tipler ile dolu olan koleksiyondaki verilerin belirtilen tipte listelenmesi sağlar.
            // OfType anahtar sözcüğü ile dizi içerisinde bulunan object değerlerden sadece belirtilen tipteki değerleri alıp yeni koleksiyonda oluşturur. Dizide bulunan string, int ve Decimal türündeki verilerden sadece int türündeki verilerin yeni bir koleksiyon olarak verilmesi örneği aşağıdaki gibidir.
            // Kod Çıktısı :5 75

            object[] values = { "Turkey", "India", 5, 75, "China", 5.25 };

            var result = values.OfType<int>();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>

        public static void OrderBy(string[] args)
        {
            // OrderBy() anahtar sözcüğü bir koleksiyon öğelerinin artan yada azalan sıraya göre listenmesini sağlar. Varsayılan olarak Asceding 'dir(Artan sıraya göre). Öğelerin azalan sıraya göre listelenmesi için Descending anahtar sözcüğü kullanılır.
            // Kod Çıktısı : Adı: Hüseyin - Soyadı: ER Adı: MAHMUT - Soyadı: GÜNAY Adı: Orhan - Soyadı: KAYA Adı: Yıldırım - Soyadı: BEYAZID

            IList<Student> students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Yıldırım",
                    LastName = "BEYAZID",
                    Ages = 20
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Orhan",
                    LastName = "KAYA",
                    Ages = 19
                },
                new Student
                {
                    Id = 2,
                    FirstName = "MAHMUT",
                    LastName = "GÜNAY",
                    Ages = 22
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Hüseyin",
                    LastName = "ER",
                    Ages = 25
                }
            };

            var result = from s in students
                         orderby s.FirstName
                         select s;

            /*
             // Asc
             var result =
                from w in words
                orderby w
                select w;

              // Desc

             var result =
                from w in words
                orderby w descending 
                select w;

             */

            foreach (var product in result)
            {
                Console.WriteLine("Adı: " + product.FirstName + " - Soyadı: " + product.LastName);
            }

            Console.ReadLine();
        }

        public static void ThenBy(string[] args)
        {
            // ThenBy() anahtar sözcüğü ile bir koleksiyon içerisinde çoklu sıralama yapılması için sağlanır.
            // Öncelikle koleksiyon OrderBy() yada OrderByDesceding() anahtar sözcüğü ile sıralanmalıdır. Bu sıralamanın ardından ThenBy() anahtar sözcüğü ile sıralama yapılır.ThenBy() anahtar sözcüğü içerisinden tanımlanan lambda sorgusuna göre artan olarak koleksiyon sıralanır.
            // Kod Çıktısı: Bursa Hatay İzmir Ankara Edirne Mardin İstanbul

            string[] citys = { "İstanbul", "Ankara", "İzmir", "Bursa", "Mardin", "Hatay", "Edirne" };
            var result = citys.OrderBy(x => x.Length).ThenBy(x => x);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            /*
            // Koleksiyonda bulunan ad ve yaş alanlarına göre Ad a göre artan ve yaşa göre artan bir sıralama örneği yapılacak. OrderBy() anahtar sözcüğü ile FirstName, ThenBy() anahtar sözcüğü ile Age olarak tanımlandığında artan sıralamaya göre FirstName ve Age alanlarına göre yeni bir koleksiyon oluşacaktır.
            // Kod Çıktısı: İsmail KARTAL Age:28 İsmail YILDIZ Age:35 Orhan ÖZ Age:32 Yılmaz ER Age:25

            var result = personnels.OrderBy(x => x.FirstName).ThenBy(x => x.Age);
            foreach (var personnel in result)
            {
                Console.WriteLine(personnel.FirstName + " " + personnel.LastName + " Age:" + personnel.Age);
            } 
            */

            Console.ReadLine();
        }

        public static void OrderByDescending(string[] args)
        {
            // OrderByDescending() anahtar sözcüğü koleksiyonda bulunan verilerin belirtilen parametrelerine göre azalan olarak listelenmesini sağlar.
            // Tanımlanan int türündeki dizideki değerlerin azalarak sıralanması sağlayan kod aşağıdaki gibidir. OrderByDesceding() anahtar sözcüğü sayıların büyükten küçüğe doğru sıralanmasını sağlar.
            // Kod Çıktısı : 12 9 7 6 5 2 1


            int[] numbers = { 1, 5, 2, 9, 12, 6, 7 };
            var result = numbers.OrderByDescending(x => x);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void ThenByDescending(string[] args)
        {
            // ThenByDescending() anahtar sözcüğü koleksiyon içerisinde bulunan verilerin çoklu sıralaması için kullanılır. 
            // ThenByDescending() anahtar sözcüğü ile koleksiyonda bulunan verilerin harf uzunluğuna göre azalan ve değere göre artan sıralama örneği aşağıdaki gibidir.
            // Kod Çıktısı : Bursa Hatay İzmir Ankara Edirne Mardin İstanbul
            string[] citys = { "İstanbul", "Ankara", "İzmir", "Bursa", "Mardin", "Hatay", "Edirne" };

            var result = citys.OrderBy(x => x.Length).ThenBy(x => x);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void Reverse(string[] args)
        {
            // Reverse() anahtar sözcüğü System.Linq kütüphanesinde bulunur. Koleksiyon içerisinde bulunan verilerin listelenme sırasını değiştirme özelliğine sahiptir. Koleksiyondaki verilerin tersine sıralanmasını sağlar.
            // Reverse anahtar sözcüğü ile dizide bulunan elemanları tersten sıralamak için kullanılır.
            // Kod Çıktısı : 5 6 2 4 3 1

            char[] numbers = { '1', '3', '4', '2', '6', '5' };

            var result = numbers.Reverse();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Other
        /// </summary>
        /// <param name="args"></param>

        public static void Zip(string[] args)
        {
            // Zip() anahtar sözcüğü iki tane koleksiyonun index sıralamalarına göre birleştirilmesini sağlar.
            // İlk koleksiyon Zip() anahtar sözcüğü ile başlayıp ikinci listeyide Zip() anahtar sözcüğü içerisindeki bölüme lambda sorgusu olarak tanımlanır. Oluşturulan Zip listeleri index sıralarına göre numaralandırır ve bu numara sonucunda listeler birleştirilir.
            // Oluşturulmuş olan personel ve departman koleksiyonlarının Zip ile numaralandırılarak birleştirilmesini sağlayacağız. Personel listesi ve departman listesi hazırlanır. Bu listede bulunan kayıtlar index numaralarına göre birbirlerinin birleşeceği sırada olmalıdır.
            // birinci listede Zip opertörü kullanılır.İkinci liste Zip operatörünün lambda kısmında linq olarak tanımlanır.Daha sonra ise iki listenin parametrelerine erişim sağlanır. 
            //Kod Çıktısı :Hüseyin AKKAYA -Muhasebe Orhan Gül -Bilgi İşlem Yıldırım Beyazıd - Hukuk

            var personnels = new List<Personnel>
            {
                new Personnel
                {
                    Id = 1,
                    FirstName = "Hüseyin",
                    LastName = "AKKAYA",
                    Age = 32
                },
                new Personnel
                {
                    Id = 2,
                    FirstName = "Orhan",
                    LastName = "Gül",
                    Age = 27
                },
                new Personnel
                {
                    Id = 5,
                    FirstName = "Yıldırım",
                    LastName = "Beyazıd",
                    Age = 29
                }
            };

            var departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "Muhasebe",
                    Address = "İstanbul"
                },
                new Department
                {
                    Id = 2,
                    Name = "Bilgi İşlem",
                    Address = "İstanbul"
                },
                new Department
                {
                    Id = 5,
                    Name = "Hukuk",
                    Address = "İstanbul"
                }
            };

            var personelDepartments =
                personnels.Zip(departments, (p, d) => p.FirstName + " " + p.LastName + " - " + d.Name);

            foreach (var item in personelDepartments)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void ZipTotal(string[] args)
        {
            // Linq Zip operatörü ile iki dizide bulunan sayıların toplanması yapan method aşağıdadır.
            //Kod Çıktısı : 15 24 38 42 57 66

            var array1 = new int[] { 10, 20, 30, 40, 50, 60 };
            var array2 = new int[] { 5, 4, 8, 2, 7, 6 };

            var result = array1.Zip(array2, (x, y) => (x + y));

            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }


        /// <summary>
        /// Grouping
        /// </summary>
        /// <param name="args"></param>
        /// 
        public static void GroupBy(string[] args)
        {
            // GroupBy() anahtar sözcüğü koleksiyondaki verilerin gruplanması için kullanılır.
            // System.Linq namespace kütüphanesinde bulunur. lambda ile sorguları yazılır.GroupBy() metodu ile birden fazla parametre tanımlayarak gruplama yapılabilir.
            // GroupBy() anahtar sözcüğü ile dizide bulunan verilerin ortak alanlarına göre gruplanması sağlanır. Aşağıdaki örnekte, koleksiyonda bulunan rakamlar iki ye tam bölünebilme durumuna göre gruplanmıştır. 1. grup ikiye tam bölünemeyen, ikinci grup ise ikiye tam bölünenler olarak ekrana çıktı verir.
            // Kod Çıktısı : Group: 1 Group Item: 1 Group Item: 3 Group Item: 5 Group Item: 7 Group Item: 9 Group: 0 Group Item: 2 Group Item: 4 Group Item: 6 Group Item: 8 Group Item: 10

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var groups = numbers.GroupBy(x => x % 2);
            foreach (var group in groups)
            {
                Console.WriteLine("Group: {0}", group.Key);

                foreach (var item in group)
                    Console.WriteLine("Group Item: {0}", item);
            }
            Console.ReadLine();
        }

        public static void ToLookup(string[] args)
        {
            // ToLookup() anahtar sözcüğü koleksiyonu indexlemeye izin veren yeni bir veri yapısı döndürür. 
            // ToLookup anahtar sözcüğü ile dizide bulunan elemanların karakter uzunluğuna göre gruplanması örneği aşağıdaki gibidir. ToLookup ile dizideki elemanlar karakter uzunluğuna göre gruplanmıştır.  lookup[8] içerisinde bulunan sekiz rakamı ile sekiz olarak gruplanmış olan dizi elemanlarını getirir.
            // Kod Çıktısı : 8 = February 8 = November 8 = December

            string[] months = new[]
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };

            var lookup = months.ToLookup(item => item.Length);
            foreach (string item in lookup[8])
            {
                Console.WriteLine("8 = " + item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Quantifiers
        /// </summary>
        /// <param name="args"></param>

        public static void Any(string[] args)
        {
            // Any() anahtar sözcüğü koleksiyonda bulunan verilerin olup olmadığını kontrol eder.
            // System.Linq namespace kütüphanesinde bulunur. Any() anahtar sözcüğü ile yazılan lambda sorgusunda koşul ifadeleri yazılabilir.Geriye dönen değerler true yada false dir.
            // Tanımlanan int türündeki dizideki değerlerin belirlenen koşullara göre koleksiyonda olup olmadığı kontrol edilir. Koşula uygun değer var ise True, yok ise False sonucu döner.
            // Kod Çıktısı : (Koleksiyonda en az bir kayıt var) True(Koleksiyonda koşulu sağlayan değer yok) False(Koleksiyonda koşulu sağlayan değer var) True(Koleksiyonda koşulu sağlayan en az bir değer var) True(Koleksiyonda koşulu sağlayan değer var) True

            int[] numbers = { 15, 21, 58, 44, 12, 14 };
            var result1 = numbers.Any();
            var result2 = numbers.Any(x => x == 10);
            var result3 = numbers.Any(x => x == 21);
            var result4 = numbers.Any(x => x == 44 || x == 78);
            var result5 = numbers.Any(x => x > 55);

            Console.WriteLine("(Koleksiyonda en az bir kayıt var) " + result1);
            Console.WriteLine("(Koleksiyonda koşulu sağlayan değer yok) " + result2);
            Console.WriteLine("(Koleksiyonda koşulu sağlayan değer var) " + result3);
            Console.WriteLine("(Koleksiyonda koşulu sağlayan en az bir değer var) " + result4);
            Console.WriteLine("(Koleksiyonda koşulu sağlayan değer var) " + result5);

            Console.ReadLine();
        }

        public static void Contains(string[] args)
        {
            // Contains() anahtar sözcüğü koleksiyonda bulunan verilerin, belirlenen koşula göre olup olmadığını kontrol eder. System.Linq namespace kütüphanesinde bulunur. Dönen değer tipi boolean'dır(true, false). 
            // Tanımlanan int türündeki List'te değerin olup olmadığı kontrol edilir. Koşula uygun değer var ise True, yok ise False sonucu döner.

            var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };
            bool result = numbers.Contains(25);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void All(string[] args)
        {
            // All() anahtar sözcüğü ile koleksiyonda bulunan tüm veriler içerisinde belirlenen koşullara göre kayıt olup olmadığını döner. Geriye dönen değer true ise kayıt var, false ise kayıt yok anlamındadır.
            // Koleksiyondaki tüm öğelerin belirtilen koşulu karşılayıp karşılamadığını kontrol eder.

            /*
            result1: Tüm öğelerda French varmı?
            result2: Tüm öğeler 'R' ile mi başlıyor?
            result3 : Tüm öğelerde 'n' harfi var mı ?
            */

            // Kod Çıktısı : False False True
            string[] languages = { "French", "English", "Russian", "Chinese" };

            var result1 = languages.All(x => x == "French");
            var result2 = languages.All(x => x.StartsWith("R"));
            var result3 = languages.All(x => x.Contains("n"));

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.ReadLine();
        }

        /// <summary>
        /// Joins
        /// </summary>
        /// <param name="args"></param>
        /// 
        public static void Join(string[] args)
        {
            // Join() anahtar kelimesi en az iki koleksiyonun birbirleri ile matche edilmesi için kullanılır. Oluşan matche sonucunda yeni bir koleksiyon oluşur.
            // Koleksiyonlarda bulunan değerlerin Join ile eşleştirilerek yeni bir dizi oluşur. Eşleşmeyen değerler oluşan yeni listede bulunmaz.
            // Kod Çıktısı : One Two Three

            string[] numbers1 = { "One", "Two", "Three", "Four", "Five" };
            string[] numbers2 = { "One", "Two", "Three", "Eight", "Seven" };

            var result = numbers1.Join(numbers2,
                num1 => num1,
                num2 => num2,
                (num1, num2) => num1);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void GroupJoin(string[] args)
        {
            // GroupJoin() anahtar kelimesi iki koleksiyonda bulunan ortak alanlara göre eşleştirilerek birleştirir.
            // GroupJoin anahtar kelimesi ile iki tane koleksiyonun ortak alanları ile yeni bir koleksiyon oluşturulur. Products ve Countries koleksiyonlarında ProductId ile birleştirilerek yeni bir koleksiyon oluşturulması örneği aşağıdaki gibidir.
            // Kod Çıktısı : Leptops 10 - Turkey---------------------- Tablests 20 - Russian---------------------- Desktops 30 - India---------------------- Monitors 40 - Avusturalia---------------------- PC Games 50 - China----------------------
            var products = new Product[]
            {
                new Product {Id = 1, Name = "Leptops", Price = 10},
                new Product {Id = 2, Name = "Tablests", Price = 25},
                new Product {Id = 3, Name = "Desktops", Price = 45},
                new Product {Id = 4, Name = "Monitors", Price = 30},
                new Product {Id = 5, Name = "PC Games", Price = 150},
            };


            var countries = new Country[]
            {
                new Country {Id = 10, ProductId = 1, Name = "Turkey"},
                new Country {Id = 20, ProductId = 2, Name = "Russian"},
                new Country {Id = 30, ProductId = 3, Name = "India"},
                new Country {Id = 40, ProductId = 4, Name = "Avusturalia"},
                new Country {Id = 50, ProductId = 5, Name = "China"},
            };

            var result = products.GroupJoin(countries, product => product.Id, country => country.ProductId,
                (product, country) => new { ProductName = product.Name, country = country });

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
                foreach (var item in product.country)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.WriteLine("----------------------");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Joins 2
        /// </summary>
        /// <param name="args"></param>
        /// 
        public static void InnerJoin(string[] args)
        {
            //  Inner Join ilişkisel veri tabanlarında iç birleştirme işlemleri için kullanılır. Birinci koleksiyon ile ikinci koleksiyonda bulunan eş öğelerin birbirine bağlanmasıyla yeni bir koleksyon ortaya çıkmasını sağlar. Inner Join ile iki koleksiyonda bulunan ve sadece eşleşen öğelerin listesini geriye döner.  Birden fazla koleksiyon eş öğelerinin Inner Join ile eşlenmesi sağlanabilir.
            // Group Join iki tablodaki eşleşen öğelere göre yeni bir koleksiyon oluşturur. Bu koleksiyon ile iki ayrı tabloda olan kayıtları iç içe koleksiyon olarak verebilir. C# linq ile Group join örneğini görelim.  list1 ile list2 koleksiyonlarını group join ile birleştirilmesi için equals anahtar sözcüğü ile into anahtar sözcüğü kullanılır. list1 de bulunan öğeler ile list2 de bulunan öğeler eşleştirildiğinde eşleşen bu öğeler into anahtar sözcüğünde tanımlanan değişkene atanır. into değişkeninide bulunan değerler ise yeni bir koleksiyonda list1 ile içiçe olarak yeni bir koleksiyon olarak ortaya çıkar. Örnek uygulama aşağıdaki gibidir.
            // Kod Çıktısı : A1-------------------- A2-------------------- A3 A3 --------------------A4 A4--------------------
            var list1 = new List<string>() {
                "A1",
                "A2",
                "A3",
                "A4"
            };

            var list2 = new List<string>() {
                "B1",
                "B2",
                "B3",
                "A3",
                "A4"
            };

            var result = from l1 in list1
                         join l2 in list2 on l1 equals l2
                             into t
                         select new { l1, r = t.ToList() };

            foreach (var item in result)
            {
                Console.WriteLine(item.l1);
                foreach (var i in item.r.ToList())
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("--------------------");
            }

            Console.ReadLine();
        }

        public static void LeftJoin(string[] args)
        {
            // Left Outer Join koleksiyonlarda sol dış birleşimi sağlar. Birinci koleksiyonda bulunan tüm elemanlar ile ikinci koleksiyonda bulunan ve ortak öğeler ile eşleşen verileri listelenir.
            // Left Join koleksiyonlarda birinci koleksiyonun tüm elemanları ile ikinci koleksiyonunu eşleşen elemanlarını listeler. C# linq ile inner left join örneğini görelim.  List1 de bulunan elemanlar ile list2 de bulunan elemanlar ortak öğelerine göre equals ile ilişkilendirilirler. Devamında into deyimi ile Left Join yapısı kurulmuş olur. List1 de bulunan tüm elemanlar ile list2 de bulunan sadece ortak elemanların listesi geriye döner. Left Join ile list1 ve list2 birleşiminden geriye dönen değerler aşağıda örnekteki gibidir.
            // Kod Çıktısı : Bir İki Üç Dört Beş On

            var list1 = new List<string>() {
                "Bir",
                "İki",
                "Üç",
                "Dört",
                "Beş",
                "On"
            };

            var list2 = new List<string>() {
                "Bir",
                "İki",
                "Üç",
                "Yedi",
                "Sekiz"
            };

            var result = from l1 in list1
                         join l2 in list2 on l1 equals l2
                             into a
                         select l1;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void CrossJoin(string[] args)
        {
            // Cross Join ilişkili tablolardaki tüm kayıtları çapraz birleşim olarak listeler. Ortak bir alan belirtilmez ve On ifadesi kullanılmaz. İki yada daha fazla tabloda, ilk tablo satır sayısı kadar diğer tablolardaki kayıtlar çarpılarak listelenir.
            // Cross Join ilişkili tablolardaki birinci tabloda bulunan kayıtları ikinci tabloda bulunan kayıtlar ile çapraz birleştirerek yeni bir koleksiyon geriye döner. C# linq ile Cross join örneğini görelim. list1 ve list2 koleksiyonlarını join ve on anahtar sözcükleri kullanmadan yazılır. list1 de bulunan her bir öğe, list2 de bulunan her öğe için çapraz olarak eşleşir. Ortaya çıkan yeni koleksiyon aşağıdaki gibidir.
            // Kod Çıktısı
            //{ l1 = A1, l2 = B1 }
            //{ l1 = A1, l2 = B2 }
            //{ l1 = A1, l2 = B3 }
            //{ l1 = A2, l2 = B1 }
            //{ l1 = A2, l2 = B2 }
            //{ l1 = A2, l2 = B3 }
            //{ l1 = A3, l2 = B1 }
            //{ l1 = A3, l2 = B2 }
            //{ l1 = A3, l2 = B3 }
            //{ l1 = A4, l2 = B1 }
            //{ l1 = A4, l2 = B2 }
            //{ l1 = A4, l2 = B3 }

            var list1 = new List<string>() {
                "A1",
                "A2",
                "A3",
                "A4"
            };

            var list2 = new List<string>() {
                "B1",
                "B2",
                "B3",
            };

            var result = from l1 in list1
                         from l2 in list2
                         select new { l1, l2 };

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// 
        public static void Select(string[] args)
        {
            // Select() anahtar sözcüğü ile koleksiyonda bulunan elementler kullanılarak yeni bir koleksiyon oluşturulur. 
            // Koleksiyonlarda bulunan değerlerin Select ile seçim yapılabilinir ve seçilen alanlar üzerinde işlem yapılabilir. Örnekte olduğu gibi koleksiyonda bulunan veriler üç ile çarpılarak ekrana yazdırılıyor.
            // Kod Çıktısı : 0 3 6 9 12 15 18 21 24 27 30

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.Select(x => x * 3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void SelectMany(string[] args)
        {
            // SelectMany() anahtar sözcüğü iki koleksiyonda bulunan ortak alanlara göre birleştirilmesi sonucunda yeni koleksiyon oluşturur.
            // SelectMany() System.Linq.Enumerable kütüphenesinde bulunur.SelectMany() anahtar sözcüğü ile iki boyutlu bir diziyi tek bir değerler dizisine dönüştürebilir.
            // Kod Çıktısı : Country: Turkey - Number: 1 Country: Turkey - Number: 2 Country: France - Number: 1 Country: France - Number: 2 Country: Russian - Number: 1 Country: Russian - Number: 2 Country: India - Number: 1 Country: India - Number: 2
            string[] countries = { "Turkey", "France", "Russian", "India" };
            int[] numbers = { 1, 2, 3, 4 };

            var result = countries.SelectMany(x => numbers, (x, n) => new
            {
                country = x,
                number = n
            });

            foreach (var item in result)
            {
                Console.WriteLine("Country: " + item.country + " - Number: " + item.number);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Elements
        /// </summary>
        /// <param name="args"></param>
        public static void First(string[] args)
        {
            // First() anahtar sözcüğü ile koleksiyonda bulunan ilk veri geriye döner.
            // Koleksiyonda bulunan değerlerden ilk olan değeri ekrana yazan program aşağıdaki gibidir.
            // Kod Çıktısı :Hüseyin

            string[] names = { "Hüseyin", "Ahmet", "Onur", "Tolgahan" };

            var result = names.First();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void FirstOrDefault(string[] args)
        {
            // FirstOrDefault() anahtar sözcüğü koleksiyonda bulunan verilerin ilk değerini döner. Eğer koleksiyonda veri yok ise Default olarak varsayılan değeri döner.
            // FirstOrDefault() metodu System.Linq kütüphanesinde bulunur.Visual Studio'unu IntelliSense özelliğindedir. IEnumerable, List, IQuerable, array vb. koleksiyonlarda kullanılır.
            // Koleksiyonda bulunan değerlerden ilk olanı yada default değeri döner. İlk koleksiyonda bulunan değeri dönerken, ikinci koleksiyonda herhangi bir değer bulunmadığından null döner.
            // Kod Çıktısı : Turkey

            string[] countries = { "Turkey", "India", "Russian", "China" };
            string[] empty = { };

            var result = countries.FirstOrDefault();
            var resultEmpty = empty.FirstOrDefault();
            Console.WriteLine(result);
            Console.WriteLine(resultEmpty);

            Console.ReadLine();
        }

        public static void ElementAt(string[] args)
        {
            // ElementAt() anahtar sözcüğü bir koleksiyonda bulunan verilerin index değerine göre listelenmesini sağlanır.
            // ElementAt anahtar sözcüğü ile dizide bulunan verilerin index numarasına göre tek eleman döner.
            // Kod Çıktısı :3


            int[] numbers = { 1, 2, 3, 4 };
            var result = numbers.ElementAt(2);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void ElementAtOrDefault(string[] args)
        {
            // ElementAtOrDefault() anahtar sözcüğü, bir koleksiyonda bulunan verilerin index değerine göre getirilmesini sağlar. Ancak verilen index değeri koleksiyon aralığı dışında ise varsayılan değeri döner.
            // ElementAtOrDefault anahtar sözcüğü ile dizi içerisinde bulunan elemanların index sırasına göre tek eleman dönmesini sağlar. istenilen dizi numarasındaki eleman dizide yok ise sıfır döner.
            //Kod Çıktısı : 3 0

            int[] numbers = { 1, 2, 3, 4, 5 };
            var result2 = numbers.ElementAtOrDefault(2);
            var result7 = numbers.ElementAtOrDefault(7);
            Console.WriteLine(result2);
            Console.WriteLine(result7);
            Console.ReadLine();
        }

        public static void Last(string[] args)
        {
            // Last() anahtar sözcüğü bir koleksiyonda bulunan son elemanı alır. Koleksiyon boş ise null döner.
            // Last anahtar sözcüğü ile dizide bulunan elemanların son elemanını ekrana veren örnek uygulama aşağıdaki gibidir.
            // Kod Çıktısı : Dizideki son değer: 5

            int[] numbers = { 10, 15, 20, 25, 5 };

            var result = numbers.Last();

            Console.WriteLine("Dizideki son değer: " + result);
            Console.ReadLine();
        }

        public static void LastOrDefault(string[] args)
        {
            // LastOrDefault() anahtar sözcüğü bir koleksiyonda bulunan elemanların son öğesini alır. Koleksiyon boş ise varsayılan değeri döner.
            // LastOrDefault anahtar sözcüğü dizide bulunan son elemanı getirir. Eğer dizide eleman yok ise default olan değeri döner.
            // Kod Çıktısı : five
            string[] words = { "one", "two", "three", "four", "five" };
            string[] wordsEmpty = { };

            var result = words.LastOrDefault();
            var resultEmpty = wordsEmpty.LastOrDefault();

            Console.WriteLine(result);
            Console.WriteLine(resultEmpty);
            Console.ReadLine();
        }

        public static void Single(string[] args)
        {
            // Single() anahtar sözcüğü koleksiyonda bulunan bir öğeyi alır.
            // Koleksiyon içerisinde bulunan elelmanlarda bir tanesinin kesin olarak gelmesi durumu var ise kullanılır. 
            //Kod Çıktısı :4

            int[] numbers = { 1, 2, 3, 4 };
            var result = numbers.Single(x => x == 4);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void SingleOrDefault(string[] args)
        {
            // SingleOrDefault() anahtar sözcüğü koleksiyon içerisinde bulunan öğelerden tek öğe döndürür. Koleksiyon boş ise varsayılan değer döner.
            // SingleOrDefault anahtar sözcüğü ile dizi içerisinde bulunan elemanlardan belirlenen koşula göre sadece bir tanesinin gelmesini sağlar. Örnekte int dizisinde bulunan elemanlardan belirlenen koşul uyuyor ise o eleman, belirlenen koşulda eleman yok ise sıfır döner. Uygulama aşağıdaki gibidir.
            // Kod Çıktısı : 2 0
            int[] numbers = { 1, 2, 3, 4 };
            var result = numbers.SingleOrDefault(x => x == 2);
            var result1 = numbers.SingleOrDefault(x => x == 7);
            Console.WriteLine(result);
            Console.WriteLine(result1);
            Console.ReadLine();
        }

        /// <summary>
        /// Partitioning
        /// </summary>
        /// <param name="args"></param>
        public static void Take(string[] args)
        {
            // Take() anahtar sözcüğü koleksiyon içerisinden listelenecek olan veri adedini belirtir. Sql Sorgu cümleciğinde Top() anahtar sözcüğüne eş değerdir.
            // Take anahtar sözcüğü ile dizide bulunan verileri başlangıç index'in den itibaren tanımlanacak olan adet kadarını ekrana yazan program aşağıdaki gibidir.
            //Kod Çıktısı : 1 2 3 4 5
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var result = numbers.Take(5);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void Skip(string[] args)
        {
            // Skip() anahtar sözcüğü koleksiyon içerisinde bulunan verilerin başlangıç index'ini belirler. Belirlenen index numarasından sonraki verileri getirir.
            // Koleksiyonda bulunan verilerin ekrana getirilme index'inin belirlendiği metotdur. months dizisinde bulunan verilerden 5. index ten sonraki verileri ekrana yazan örnek aşağıdaki gibidir.
            // Kod Çıktısı : August September October November December

            string[] months =
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };

            var result = months.Skip(5);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void TakeWhile(string[] args)
        {
            // TakeWhile() anahtar sözcüğü Koleksiyon da bulunan verilerin, belirlenen koşul neticesinde listelenmesini sağlar.
            // TakeWhile anahtar sözcüğü ile koşul eklenerek dizide bulunan verileri başlangıç index'in den itibaren tanımlanacak olan adet kadarını ekrana yazan program aşağıdaki gibidir. 
            // Kod Çıktısı : February March
            string[] months =
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };

            var result = months.TakeWhile(x => x.Length > 3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void SkipWhile(string[] args)
        {
            // SkipWhile() anahtar sözcüğü koleksiyonda bulunan verilerin, belirtilen koşul neticesinde başlangıç index'ine göre listelenmesini sağlar.
            // Koleksiyonda bulunan verilerin ekrana getirilme index'inin belirlenen koşula göre çalıştıran metotdur. months dizisinde bulunan verilerden belirlenen koşula göre ekrana yazan örnek aşağıdaki gibidir.
            // Kod Çıktısı : September October November December

            var months = new List<string>
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };

            var result = months.SkipWhile(x => x.Length < 9);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Concatenation
        /// </summary>
        /// <param name="args"></param>
        public static void Concat(string[] args)
        {
            // Concat() anahtar sözcüğü iki tane koleksiyonun elemanlarını birleştirir. İlk koleksiyonun elemanlarından sonra ikinci koleksiyonun elemanları listelenecek şekilde yeni bir koleksiyon oluşur.
            // Concat anahtar sözcüğü ileiki koleksiyondaeki elemanların sırası ile birleştirilmesi sağlar.
            // Kod Çıktısı : A B C D E F G H

            string[] alphabet1 = { "A", "B", "C", "D" };
            string[] alphabet2 = { "E", "F", "G", "H" };

            var result = alphabet1.Concat(alphabet2);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Equality
        /// </summary>
        /// <param name="args"></param>

        public static void SequenceEqual(string[] args)
        {
            // SequenceEqual() anahtar sözcüğü iki koleksiyonda bulunan öğelerin bir birine eşit olup olmamasını döner. Birinci koleksiyonun öğeleri, ikinci koleksiyonunu öğelerine eşit ise true değilse false döner.
            // SequenceEqual anahtar sözcüğü değerler, koleksiyonlar gibi verilerin birbirine eşit olup olmadığını kontrol eden bir metotdur. Örnekte olduğu gibi dizide bulunan elemanların sırası ve büyük küçük harf kontrolü dahil eşitlik kontrol edilmektedir.
            // result3 sonucu dizideki elemanların index sırası ve büyük küçük harf olarak birbirine eşit olması nedeni ile True olarak dömüş ve diğer sonuçlar ise eşitlik olmadığında False olarak dönmüştür.
            // Kod Çıktısı : False False True False

            string[] words1 = { "February", "March", "May" };
            string[] words2 = { "February", "May", "March" };
            string[] words3 = { "MARCH", "February", "May" };
            string[] words4 = { "February", "March", "May" };
            string[] words5 = { "February", "MARCH", "May" };

            var result1 = words1.SequenceEqual(words2);
            var result2 = words1.SequenceEqual(words3);
            var result3 = words1.SequenceEqual(words4);
            var result4 = words1.SequenceEqual(words5);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
            Console.ReadLine();
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="args"></param>

        public static void Distinct(string[] args)
        {
            // Distinct() anahtar sözcüğü koleksiyon içerisinde bulunan tekrarlayan kayıtların gösterilmesini engeller.
            // Koleksiyonda bulunan verilerin tekrarlayan kayıtların tekrarlanmamasını sağlar. Koleksiyonda bulunan günlerde tekrarlayan günler mevcut ve aşağıdaki örnekte tekrarlayan kayıtların ekrana yazılması engellenir.
            // Kod Çıktısı : Monday Tuesday Wednesday Thursday Sunday Saturday

            string[] numbers = { "Monday", "Tuesday", "Tuesday", "Wednesday", "Thursday", "Thursday", "Sunday", "Saturday", "Saturday", "Saturday" };

            var result = numbers.Distinct();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void Union(string[] args)
        {
            // Union() anahtar sözcüğü iki koleksiyonda bulunan verilerin tekrarlayanları olmadan, koleksiyon verilerini geri döner.
            // Farklı iki koleksiyonda bulunan verilerin tekrarlayanlarını dahil etmeden yeni bir koleksiyon oluşturur. Örnekte bulunan iki koleksiyonda da aynı değerler mevcuttur. Union ile bu koleksiyonlar birleştirilir ve tekrarlayan değerler yeni oluşan koleksiyonda bulunmaz.
            // Kod Çıktısı : Monday Tuesday Wednesday Thursday Friday Sunday Saturday

            var days1 = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            var days2 = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Sunday", "Saturday" };

            var result = days1.Union(days2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void Intersect(string[] args)
        {
            // Intersect() anahtar sözcüğü iki koleksiyonda bulunan tekrarlayan kayıtların listelenmesini sağlar.
            // Intersect anahtar sözcüğü ile iki koleksiyonda bulunan ve tekrarlayan kayıt var ise sadece tekrarlayan kayıtları yeni bir koleksiyon olarak döner. Aşağıdaki örnekte bulunan koleksiyonlarda Intersect anahtar sözcüğü ile tekrarlayan değerlerin listesini verir.
            // Kod Çıktısı : 20

            int[] numbers1 = { 5, 10, 20 };
            int[] numbers2 = { 20, 25, 30 };

            var result = numbers1.Intersect(numbers2);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void Except(string[] args)
        {
            // Except() Anahtar sözcüğü, iki koleksiyonda bulunan verilerin sadece ilk koleksiyonda olup ikinci koleksiyonda olmayan kayıtları listeler.
            // Except anahtar sözcüğü ile iki koleksiyon birleştirilir ve bu birleştirme sonucunda sadece ilk koleksiyonda bulunan ve ikinci koleksiyonda bulunmayan değerler listesini ekrana verir.
            // Kod Çıktısı : a b

            string[] numbers1 = { "a", "b", "c", "d" };
            string[] numbers2 = { "c", "d", "e", "f" };

            var result = numbers1.Except(numbers2);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Conversion
        /// </summary>
        /// <param name="args"></param>
        public static void ToArray(string[] args)
        {
            // ToArray() anahtar sözcüğü koleksiyonda bulunan verileri diziye dönüştürür.
            // List vb. koleksiyonda bulunan veriler ToArray() anahtar sözcüğü ile diziye dönüştürülür.
            // Kod Çıktısı : Type: Int32[] 1 2 3 4 5 6 7 8 9

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var result = numbers.ToArray();
            Console.WriteLine("Type: " + result.GetType().Name);
            Console.WriteLine();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void ToList(string[] args)
        {
            // ToList() anahtar sözcüğü koleksiyonda bulunan verilerin list'e dönüştürür.
            // ToList anahtar sözcüğü koleksiyonda bulunan verileri seçilen eleman tipine göre ekrana döndürür.
            // Kod Çıktısı : months: String[] result: List`1 February March May June July August September October November December

            string[] months = new[]
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };

            List<string> result = months.ToList();
            Console.WriteLine("months: " + months.GetType().Name);
            Console.WriteLine("result: " + result.GetType().Name);
            Console.WriteLine();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void ToDictionary(string[] args)
        {
            // ToDictionary() anahtar sözcüğü koleksiyonda bulunan verilerin Key ve Value değerleri tanımlanarak Dictionary dönüştürür.
            // ToDictionary anahtar sözcüğü ile dizide bulunan verileri Dictionary türüne dönüştürmek için kullanacağız. Dizi elemanları Key, dizi elemanlarının ikiye bölünebilme durumları Value olacak şekilde yeni bir veri türü oluşturulması örneği aşağıdaki gibidir.
            // Kod Çıktısı
            //[1, True]
            //[2, False]
            //[3, True]
            //[4, False]
            //[5, True]
            //[6, False]
            //[7, True]
            //[8, False]
            //[9, True]

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var result = numbers.ToDictionary(x => x, y => (y % 2) == 1);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void Cast(string[] args)
        {
            // Cast() anahtar sözcüğü özel tipler ile dolu olan koleksiyondaki verileri belirtilen tipe atayarak, tek tipte yeni bir koleksiyon olarak sunar.
            // Kod Çıktısı : February March May June July August September October November December
            var months = new List<string>
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };
            var result = months.Cast<string>();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void AsEnumerable(string[] args)
        {
            // AsEnumerable() anahtar sözcüğü koleksiyonu IEnumerable a dönüştürür.
            // AsEnumerable anahtar sözcüğü ile string türündeki List'i IEnumerable türüne dönüştürme örneği aşağıdaki gibidir.
            // Kod Çıktısı : February March May June July August September October November December

            var months = new List<string>
            {
                "February", "March", "May", "June", "July", "August", "September", "October", "November",
                "December"
            };
            var result = months.AsEnumerable();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }


        /// <summary>
        /// Generation
        /// </summary>
        /// <param name="args"></param>

        public static void Range(string[] args)
        {
            // Range() anahtar sözcüğü belirtilen iki değer arasındaki tam sayı değerlerinin koleksiyon halinde dönmesini sağlar.
            // Range anahtar sözcüğü ile Enumerable üzerinden girilen ilk alan başlangıç tamsayısı ve ikinci alan ise başlangıçtan itibaren verilen değer kadar bir artarak ekrana yazan program aşağıdaki gibidir.
            // Kod Çıktısı :6 7 8 9 10 11

            var result = Enumerable.Range(6, 6);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void Repeat(string[] args)
        {
            // Repeat() anahtar sözcüğü, Yenilenen değerleri belirtilen adette bir koleksiyonda listelenmesini sağlar. Bu değerler tekrarlananacak olan kayıtlardır. Repeat() anahtar sözcüğünde birinci argüman tekrarlanacak olan kelime, ikinci argüman ise kaç defa tekrarlanacağı sayısını ifade eder.
            // Repeat anahtar sözcüğü ile belirlenen değerin belirlenen adet kadar çoğaltılmasını sağlar. String içerisinde tanımlanan değerin on adet kadar çoğaltılarak alt alta ekrana yazılması örneği aşağıdaki gibidir.
            // Kod Çıktısı : February February February February February February February February February February

            string month = "February";

            var result = Enumerable.Repeat(month, 10);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void DefaultIfEmpty(string[] args)
        {
            // DefaultIfEmpty() anahtar sözcüğü koleksiyon bulunan varsayılan öğeyi döndürür. Koleksiyon boş ise varsayılan değer tipi döndürülür.
            // DefaultIfEmpty anahtar sözcüğü ile belirtilen koleksiyon boş ise varsayılan koleksiyon türüyle geriye döner.
            // Kod Çıktısı : True True True

            string[] emptyString = { };
            int[] emptyInt = { };
            double[] emptyDouble = { };

            var resultString = emptyString.DefaultIfEmpty();
            Console.WriteLine(resultString.First() == null);

            var resultInt = emptyInt.DefaultIfEmpty();
            Console.WriteLine(resultInt.First() == 0);

            var resultDouble = emptyDouble.DefaultIfEmpty();
            Console.WriteLine(resultDouble.First() <= 0);

            Console.ReadLine();
        }

        public static void Empty(string[] args)
        {
            // Empty() anahtar sözcüğü hiçbir öğe içermeyen bir koleksiyon oluşturur. Koleksiyonda herhangi bir öğe gönderilmesi istenmediği taktirde kullanılır.
            // Empty anahtar sözcüğü ile boş bir koleksiyon oluşturulur.
            // Kod Çıktısı :System.Int32[] True
            var empty = Enumerable.Empty<int>();
            Console.WriteLine(empty);
            Console.WriteLine(!empty.Any());
            Console.ReadLine();
        }

        /// <summary>
        /// Model
        /// </summary>

        public class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ProductId { get; set; }
        }


        public class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Ages { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public decimal Price { get; set; }
        }

        public class Personnel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }

    }
}
