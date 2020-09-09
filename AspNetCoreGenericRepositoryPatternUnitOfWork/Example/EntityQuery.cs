using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Helper
{
    public class EntityQuery
    {
        protected void Notlar()
        {
            // order by id asc ---- orderby x.id ascending
            // order by id desc ---- orderby x.id descending

            // select *  ---- select x
            // select Kategori, KategoriTitle, KategoriUrl ---- select new { x.Kategori, x.KategoriTitle, x.KategoriUrl }
            // select Kategori as BenimKategori ---- select new { BenimKategori = x.Kategori }


            //select count(*) fiyat from Urunler ---- (from u in Urun.Urunler() select u).Count(); 
            //select sum(Stok) fiyat from Urunler ----- (from u in Urun.Urunler() select u).Sum(u=> u.Stok);
            //select avg(Stok) fiyat from Urunler -----  (from u in Urun.Urunler() select u). Average (u=> u.Stok);
            //select max(Stok) fiyat from Urunler ----- (from u in Urun.Urunler() select u).Max(u=> u.Stok);
            //select min(Stok) fiyat from Urunler ----- (from u in Urun.Urunler() select u).Min(u=> u.Stok);
            //select top 5* Fiyat from Urunler  ------  (from u in Urun.Urunler() select u).Take(5);

            //where Kategori='Saat'  ------  x.Kategori.Equals("Saat") 
            //where Kategori<>'Saat'  ------  !x.Kategori.Equals("Saat") 

            // from Tbl_Kategoriler ---- from x in Baglanti.db.Tbl_Kategoriler

            // top 1 ---- Take(1)

            // DataTable  ----  ToList() (Aynı Değil Sadece Birden Fazla Kaydı Listelemek İçin)
            // DataRow  ----  FirstOrDefault() (Aynı Değil Sadece Tek Kayıt İçin)
            // rs.Rows[0]["Kategori"].ToString()  ---- rs.Kategori.ToString()

            //where id=1 ----  where x.id == 1
            //where id=1 and Kategori='Saat'----  where x.id == 1 && x.Kategori=="Saat"
            //where id=1 or Kategori='Saat'----  where x.id == 1 || x.Kategori=="Saat"

            //where Kategori Like 's %' ---- where x.Kategori.StartsWith("s")
            //where Kategori Like '% t ' ---- where x.Kategori.EndsWith("t")
            //where Kategori Like '% saat %' ---- where x.Kategori.Contains("saat")

            //where id=1 and Kategori="Saat" ---- where x.id == 1 && x.Kategori=="Saat"
            //where id=1 or Kategori="Saat" ---- where x.id == 1 || x.Kategori=="Saat"

        }
        //--------------------------------------------------------------------------------------------------------------------

        /*
        protected void GenelBilgiler()
        {
            //Min, dizideki en küçük elemanın değerini döndürür, elemanın IComparable arayüzünden implement edilmiş olması gereklidir.
            //Max, dizideki en büyük elemanın değerini döndürür. Min ile aynı kullanımı sahiptir.
            //Sum, dizideki tüm elemanların toplamını döndürür.
            //Count, dizideki eleman sayısını verir. Toplam eleman sayısını verebileceği gibi, belirli kriterlerin uygulandığı eleman sayısının toplamını da verebilir.
            //FirstOrDefault, kritere uyan ilk elemanı döndürür. Herhangi bir kriter belirlenmezse dizideki ilk elemanı döndürür.
            //Any, dizide kritere uygun eleman olup olmadığını bool cinsinden döndürür, kriter girilmezse dizide eleman olup olmadığını kontrol eder.
            //Skip, girilen parametre kadar (int) dizinin başından o kadar elemanı atlar.
            //Take, girilen parametre kadar (int) diziden o kadar elemanı seçer.
            //OrderBy, dizideki elemanları girilen kritere göre A'dan Z'ye sıralar
            //OrderByDescending, dizideki elemanları girilen kritere göre Z'den A'ya sıralar.
            //Distinct, dizideki elemanları seçer ancak aynı değere sahip elemanları tek alır, dizide 5 adet elemanın değeri 2 ise, 1 adet 2 döner.
            //Select, her bir dizi elemanı içinden sadece belirli tipleri seçmeyi sağlar, "new" anahtar kelimesi altında çoklu alan seçilirse dönen değer anonimdir ve "var" olarak tanımlanmalıdır.
            //ToDictionary, çift parametreli olarak diziyi Dictionary tipine aktarır.
            //ToArray, IEnumerable<tip> olarak dönen diziyi tip[] şeklinde diziye çevirir.
            //ToList, IEnumerable<tip> olarak dönen diziyi List<tip> şeklinde diziye çevirir.
            //Except, dizinin, parametre olarak girilen 2. dizide olmayan elemanlarını listeler.
            //Union, diziye, parametre olarak girilen 2. dizinin elemanlarını ekler.
            //Intersect, dizinin, paramatre olarak girilen 2. dizi ile olan ortak elemanlarını listeler.
        }
        //--------------------------------------------------------------------------------------------------------------------


        protected void TumListe()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            rs = Baglanti.db.Tbl_Kategoriler.ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void TekliVeriListe()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).FirstOrDefault();
            if (rs != null)
            { Response.Write(rs.Kategori.ToString()); }
            //------------------------------------------------------------

            Tbl_Kategoriler rsf = (from x in Baglanti.db.Tbl_Kategoriler select x).FirstOrDefault();
            if (rsf != null)
            { Response.Write(rsf.Kategori.ToString()); }
            //------------------------------------------------------------

            var rsq = (from x in Baglanti.db.Tbl_Kategoriler select new { x.Kategori, x.KategoriTitle, x.KategoriUrl }).FirstOrDefault();
            if (rsq != null)
            { Response.Write(rsq.Kategori.ToString()); }
            //------------------------------------------------------------- 

            var rsz = (from x in Baglanti.db.Tbl_Kategoriler select new { BenimKategori = x.Kategori }).FirstOrDefault();
            if (rsz != null)
            { Response.Write(rsz.BenimKategori.ToString()); }
            //------------------------------------------------------------- 

            var rst = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select new { x.Kategori, x.KategoriTitle, x.KategoriUrl }).Take(1).FirstOrDefault();
            if (rst != null)
            { Response.Write(rst.Kategori.ToString()); }
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void TekliTumVeriListe()
        {

            var rs = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending select x).ToList();
            if (rs.Count > 0)
            { Response.Write(rs.FirstOrDefault().Kategori.ToString()); }

            //------------------------------------------------------------- 
            var rsq = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending select new { x.Kategori, x.KategoriTitle, x.KategoriUrl }).Take(1).ToList();
            if (rsq.Count > 0)
            { Response.Write(rsq.FirstOrDefault().Kategori.ToString()); }

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void DonguluListe()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending, x.Sira descending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

            //-------------------------------------------------------------------
            foreach (var alan in Baglanti.db.Tbl_Kategoriler)
            { Response.Write(alan.Kategori + "<br>"); }

            //-------------------------------------------------------------------
            foreach (var alan in Baglanti.db.Tbl_Kategoriler.OrderByDescending(u => u.Kategori))
            { Response.Write(alan.Kategori + "<br>"); }
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void AramaKlasik()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler where x.id == 1 orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.id == 1 && x.Kategori == "Saat" orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.id == 1 || x.Kategori == "Saatler" orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.id >= 2 && x.id <= 4 orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //---------------------------------------------------------------------------------------- 

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Tarih >= DateTime.Parse("10.10.2013") && x.Tarih < DateTime.Parse("10.12.2013") orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.id % 2 == 1 orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.Equals("Saat") orderby x.id descending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where !x.Kategori.Equals("Saat") orderby x.id descending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void LikeArama()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.StartsWith("s") orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.EndsWith("t") orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.Contains("t") orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.ToUpper().Contains("t") orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void SelectFonksiyonlari()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler select new { x.Kategori }).Count();
            if (rs != null)
            { Response.Write(rs.ToString()); }
            //----------------------------------------------------------------------------------------

            var rsd = (from x in Baglanti.db.Tbl_Kategoriler select new { x.Kategori }).Distinct();
            foreach (var alan in rsd)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------

            var rsf = (from x in Baglanti.db.Tbl_Fiyatlar select x).Sum(x => x.Fiyat);
            if (rsf != null)
            { Response.Write(rsf.Value); }
            //----------------------------------------------------------------------------------------

            var rsa = (from x in Baglanti.db.Tbl_Fiyatlar select x).Average(x => x.Fiyat);
            if (rsa != null)
            { Response.Write(rsa.Value); }
            //----------------------------------------------------------------------------------------

            var rsm = (from x in Baglanti.db.Tbl_Fiyatlar select x).Min(x => x.Fiyat);
            if (rsm != null)
            { Response.Write(rsm.Value); }
            //----------------------------------------------------------------------------------------


            var rsmx = (from x in Baglanti.db.Tbl_Fiyatlar select x).Max(x => x.Fiyat);
            if (rsmx != null)
            { Response.Write(rsmx.Value); }
            //----------------------------------------------------------------------------------------

            var rsv = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).Take(5).Skip(2);
            foreach (var alan in rsv)
            { Response.Write(alan.Kategori + "<br>"); }
            //----------------------------------------------------------------------------------------


        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void JoinFonksiyonlari()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler join y in Baglanti.db.Tbl_Kayitlar on x.id equals y.CatID select new { y.Baslik }).ToList();
            foreach (var alan in rs)
            {
                Response.Write(alan.Baslik + "<br>");
            }
            //----------------------------------------------------------------------------------------

            var RightJoin = (from x in Baglanti.db.Tbl_Kategoriler join y in Baglanti.db.Tbl_Kayitlar on x.id equals y.CatID into joindeptEmp from y in joindeptEmp.DefaultIfEmpty() select new { x.Kategori, y.Baslik });
            foreach (var alan in RightJoin)
            {
                Response.Write(alan.Baslik + "<br>");
            }
            //----------------------------------------------------------------------------------------

            var LeftJoin = from y in Baglanti.db.Tbl_Kayitlar join x in Baglanti.db.Tbl_Kategoriler on y.CatID equals x.id into JoinedEmpDept from dept in JoinedEmpDept.DefaultIfEmpty() select new { y.Baslik };
            foreach (var alan in LeftJoin)
            {
                Response.Write(alan.Baslik + "<br>");
            }
            //----------------------------------------------------------------------------------------

            var crossjoin = from s in Baglanti.db.Tbl_Kategoriler from c in Baglanti.db.Tbl_Kayitlar where s.id == 1 || s.id == 3 select new { s.id, s.Kategori, kayitid = c.id, c.Baslik };
            foreach (var alan in crossjoin)
            { Response.Write(alan.kayitid + "<br>"); }
            //----------------------------------------------------------------------------------------

            var uclujoin = (from x in Baglanti.db.Tbl_Kategoriler join k in Baglanti.db.Tbl_Kullanicilar on x.UserID equals k.id join y in Baglanti.db.Tbl_Kayitlar on k.id equals y.UserID select new { y.Baslik }).Distinct();
            foreach (var alan in uclujoin)
            { Response.Write(alan.Baslik + "<br>"); }
            //----------------------------------------------------------------------------------------

            var joinwhere = (from x in Baglanti.db.Tbl_Kategoriler join y in Baglanti.db.Tbl_Kayitlar on x.id equals y.CatID where x.Kategori.Contains("a") select new { y.Baslik }).ToList();
            foreach (var alan in joinwhere)
            {
                Response.Write(alan.Baslik + "<br>");
            }
            //----------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void GroupByFonksiyonlari()
        {
            var rs = (from k in Baglanti.db.Tbl_Kategoriler join u in Baglanti.db.Tbl_Kayitlar on k.id equals u.CatID group u by k into g select new { KategoriAdi = g.Key.Kategori, UrunAdedi = g.Count() }).ToList();
            foreach (var alan in rs)
            {
                Response.Write(alan.KategoriAdi + "<br>");
            }
            //----------------------------------------------------------------------------------------

            var rsh = (from k in Baglanti.db.Tbl_Kategoriler join u in Baglanti.db.Tbl_Kayitlar on k.id equals u.CatID group u by k into g where g.Count() > 2 select new { KategoriAdi = g.Key.Kategori, UrunAdedi = g.Count() }).ToList();
            foreach (var alan in rsh)
            {
                Response.Write(alan.KategoriAdi + "<br>");
            }
            //----------------------------------------------------------------------------------------

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void SubqueryFonksiyonlari()
        {
            var rs = (from y in Baglanti.db.Tbl_Kayitlar select new { y.Baslik, KategoriAdim = (from x in Baglanti.db.Tbl_Kategoriler where x.id == y.CatID select x.Kategori).SingleOrDefault() }).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.KategoriAdim + " ------- " + alan.Baslik + "<br>"); }
            //----------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void EkFonksiyonlar()
        {

            //All metodu, verdiğimiz koşul kaynaktaki tüm elemanlar tarafından sağlanıyorsa true döner, bir tanesi bile koşulu bozuyorsa false döner. 
            var rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.StartsWith("s") orderby x.id ascending select x).ToList().Any();
            Response.Write(rs);

            //Any metodu ise, koşulu sağlayan herhangi bir eleman varsa true döner, hiçbiri sağlamıyor ise false döner.
            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Kategori.StartsWith("s") orderby x.id ascending select x).Any();
            Response.Write(rs);

            //------------------------------------------------------------------------------------------------------------------------------
            //Parametre olarak verilen index'e sahip elemanı geriye döndürür. ElementAt metodu, verilen index’e sahip bir eleman mevcut değilse hata verir, ElementAtOrDefault metodu ise o tipin default değerini döner.
            var rse = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending select new { x.Kategori }).ToList().ElementAtOrDefault(0);
            Response.Write(rse.Kategori);

            rse = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending select new { x.Kategori }).ToList().ElementAt(1);
            Response.Write(rse.Kategori);

            //------------------------------------------------------------------------------------------------------------------------------
            //Verilen koşul sağlandığı sürece okuma yapar. While döngüsü gibi düşünebiliriz.
            var rsw = (from f in Baglanti.db.Tbl_Fiyatlar select f).ToList().TakeWhile(f => f.Fiyat < 60);
            foreach (var alan in rsw)
            { Response.Write(alan.Fiyat + "<br>"); }


            foreach (var alan in Baglanti.db.Tbl_Fiyatlar.OrderByDescending(u => u.Fiyat).ToList().TakeWhile(u => u.Fiyat > 30))
            { Response.Write(alan.Fiyat + "<br>"); }


            //------------------------------------------------------------------------------------------------------------------------------
            //Verilen koşul sağlanmadığıdı sürece okuma yapar. While döngüsü gibi düşünebiliriz. TakeWhile tam tersidir.
            foreach (var alan in Baglanti.db.Tbl_Fiyatlar.OrderByDescending(u => u.Fiyat).ToList().SkipWhile(u => u.Fiyat > 30))
            { Response.Write(alan.Fiyat + "<br>"); }

            //---------------------------------------------------------------------------------------
            //First ve FirstOrDefault metotları, LINQ kaynağındaki ilk sonucu elde etmemizi sağlar. Single metodu ise, eğer verdiğimiz koşulu sağlayan başka bir eleman varsa, yani koşuldan geçen eleman sayısı birden fazla ise hata almamızı sağlar. SingleOrDefault metodu da, geriye bir eleman dönmez ise o tipin default değerini elde etmemizi sağlar.
            Tbl_Fiyatlar rsf = Baglanti.db.Tbl_Fiyatlar.Where(u => u.Fiyat > 70).SingleOrDefault();
            Response.Write(rsf.Fiyat);

            rsf = Baglanti.db.Tbl_Fiyatlar.Where(u => u.Fiyat > 70).Single();
            Response.Write(rsf.Fiyat);

            rsf = Baglanti.db.Tbl_Fiyatlar.Where(u => u.Fiyat > 70).SingleOrDefault();
            Response.Write(rsf.Fiyat);

            //---------------------------------------------------------------------------------------
            //LINQ Sorgularından elde edilen sorgu nesnesini çalıştırarak, filtreden geçen ilk elemanı elde etmemizi sağlarlar. First metotu, eğer sorgu nesnesinden sonuç gelmesse hata verir, ancak FirstOrDefault metodu, o tipin default değerini döndürür.
            var rsq = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).FirstOrDefault();
            Response.Write(rsq.Kategori.ToString());

            rsq = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).First();
            Response.Write(rsq.Kategori.ToString());

            //---------------------------------------------------------------------------------------
            //Skıp komutu ise verdiğimiz parametreden başlayarak verilerimizi bize getirir.Örneğin aşağıda 3 ‘den sonraki tablomuzdaki bulunan kayıtları getirir.
            var rsv = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).Skip(4);
            foreach (var alan in rsv)
            { Response.Write(alan.Kategori + "<br>"); }

            //---------------------------------------------------------------------------------------

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void IN_NotIN_Fonksiyonlar()
        {
            string[] strArray = { "1", "2", "3", "4", "5" };
            var rs = (from x in Baglanti.db.Tbl_Kategoriler where strArray.Contains(x.id.ToString()) orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where !strArray.Contains(x.id.ToString()) orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            //int[] arr = islem.CokluKategoriIDSec("3").Split(',').Select(i => Convert.ToInt32(i)).ToArray();
            //var dt = (from x in BaglantiLink.db.Tbl_Genel_Kayitlars where arr.Contains(Convert.ToInt32(x.CatID)) && x.Onay == true && x.SilDurum == false orderby x.Sira ascending select x).Take(3).ToList();
            //foreach (var alan in dt)
            //{ Response.Write(alan.Kategori + "<br>"); }

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void ArrayFonksiyonlar()
        {
            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sorgu = from sor in sayilar where sor >= 5 select sor;
            foreach (var eleman in sorgu)
            { Response.Write(eleman.ToString() + "<br>"); }
            //------------------------------------------------------------------------------

            string[] sehirler = { "Ankara", "İzmir", "Adana", "Antalya", "İstanbul", "Kayseri", "Malatya" };
            var rs = from sor1 in sehirler where sor1.StartsWith("A") == true orderby sor1 ascending select sor1;
            foreach (var alan in rs)
            { Response.Write(alan.ToString() + "<br>"); }
            //------------------------------------------------------------

            int[] sonucKumesi2 = Baglanti.db.Tbl_Kategoriler.Select(u => u.id).ToArray();
            Response.Write(sonucKumesi2[1]);
            //------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void TrueFalseDurumlari()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Onay == true orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where x.Onay == false orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where (bool)x.Onay orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            rs = (from x in Baglanti.db.Tbl_Kategoriler where !(bool)x.Onay orderby x.id ascending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void SartliSorgulamaKlasik()
        {
            string strbaslik = "";
            int strcatid = 1;
            //--------------------------------------------------------------------------
            var q = (from x in Baglanti.db.Tbl_Kayitlar where x.id > 0 select x).ToList();
            if (Convert.ToInt32(strcatid) > 0)
            {
                q = (from x in q where x.CatID == Convert.ToInt32(strcatid) select x).ToList();
            }
            if (!string.IsNullOrEmpty(strbaslik))
            {
                q = (from x in q where x.Baslik.Contains(strbaslik) select x).ToList();
            }
            q = (from x in q orderby x.Sira descending, x.id ascending select x).ToList();
            //--------------------------------------------------------------------------
            foreach (var alan in q)
            { Response.Write(alan.Baslik + "<br>"); }
            //------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void SartliSorgulama()
        {
            string strbaslik = "";
            int strcatid = 1;
            //--------------------------------------------------------------------------
            var q = from x in Baglanti.db.Tbl_Kayitlar where x.id > 0 select x;
            if (Convert.ToInt32(strcatid) > 0)
            {
                q.Where(e => e.CatID == Convert.ToInt32(strcatid));
            }
            if (!string.IsNullOrEmpty(strbaslik))
            {
                q.Where(e => e.Baslik.Contains(strbaslik));
            }
            q = from x in q orderby x.Sira descending, x.id ascending select x;
            //--------------------------------------------------------------------------
            foreach (var alan in q)
            { Response.Write(alan.Baslik + "<br>"); }
            //------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void BirlesikVerilisteme()
        {
            var q = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select new { birlesikveri = x.Kategori + " / " + x.KategoriTitle }).ToList();
            foreach (var alan in q)
            { Response.Write(alan.birlesikveri + "<br>"); }
        }
        //--------------------------------------------------------------------------------------------------------------------


        protected void RandomVerilisteme()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler orderby Guid.NewGuid() select x);
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void DurumaGoreEkFonksiyonlar()
        {
            var sozluk = (from x in Baglanti.db.Tbl_Kayitlar select x).ToDictionary(x => x.Baslik, x => x.id);
            Response.Write(sozluk["Mavi Puantiye Retro B."]);
            //------------------------------------------------------------

            var Veriler = (from p in Baglanti.db.Tbl_Kategoriler select p).OrderBy(p => p.Sira).ThenBy(s => s.Kategori);
            foreach (var alan in Veriler)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void OderbyFonksiyonlar()
        {
            var rs = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id descending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            var rst = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending select new { x.Kategori, x.KategoriTitle, x.KategoriUrl }).Take(1).FirstOrDefault();
            if (rst != null)
            { Response.Write(rst.Kategori.ToString()); }

            rs = (from x in Baglanti.db.Tbl_Kategoriler orderby x.id ascending, x.Sira descending select x).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

            //ThenBy siralama ikinci bölüm için kullanılır asc gibi görev yapar
            var Veriler = (from p in Baglanti.db.Tbl_Kategoriler select p).OrderBy(p => p.Sira).ThenBy(s => s.Kategori);
            foreach (var alan in Veriler)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

            //ThenByDescendingsiralama ikinci bölüm için kullanılır desc gibi görev yapar
            Veriler = (from p in Baglanti.db.Tbl_Kategoriler select p).OrderBy(p => p.Sira).ThenByDescending(s => s.Kategori);
            foreach (var alan in Veriler)
            { Response.Write(alan.Kategori + "<br>"); }
            //------------------------------------------------------------

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void DigerFonksiyonlar()
        {
            // Bildiğimiz union
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var uniqueNumbers = numbersA.Union(numbersB);
            foreach (var n in uniqueNumbers)
            { Response.Write(n); }
            //--------------------------------------------------------------

            // Bildiğimiz union All
            int[] numbers1 = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbers2 = { 1, 3, 5, 7, 8 };
            var uniqueNumbers1 = numbers1.Concat(numbers2);
            foreach (var n in uniqueNumbers1)
            { Response.Write(n); }
            //--------------------------------------------------------------


            //koşula uygun en büyük sayının degeri 
            int[] sayilar = { 1, 3, 5, 7, 8 };
            var rs = sayilar.ToList().FindLast(s => s < 5);
            Response.Write(rs);
            //--------------------------------------------------------------


            // koşula uygun en büyük sayısının index numarası
            int[] sayilar1 = { 1, 3, 5, 7, 8 };
            var rs1 = sayilar1.ToList().FindLastIndex(s => s < 5);
            Response.Write(rs1);
            //--------------------------------------------------------------


            // koşula uygun ise True yoksa False geri donüş yapacak
            int[] sayilar2 = { 1, 3, 5, 7, 8 };
            var rs2 = sayilar2.ToList().Exists(s => s < 5);
            Response.Write(rs2);
            //--------------------------------------------------------------


            // koşula uymasa 0 değeri döner ekmek olsa yesek
            int[] sayilar3 = { 1, 3, 5, 7, 8 };
            var rs3 = sayilar3.ToList().FirstOrDefault(s => s > 10);
            Response.Write(rs3);
            //--------------------------------------------------------------


            // koşula uyan ilk kaydı getirir	
            int[] sayilar4 = { 1, 3, 5, 7, 8 };
            var rs4 = sayilar4.ToList().First(s => s < 5);
            Response.Write(rs4);
            //--------------------------------------------------------------


            //ilk kayıt
            int[] sayilar5 = { 1, 3, 5, 7, 8 };
            var rs5 = sayilar5.ToList().First();
            Response.Write(rs5);
            //--------------------------------------------------------------


            //son kayıt
            int[] sayilar6 = { 1, 3, 5, 7, 8 };
            var rs6 = sayilar6.ToList().Last();
            Response.Write(rs6);
            //--------------------------------------------------------------


            // koşua uygun değilse fefault sayı 5 olarak kalacak
            int[] sayilar7 = { 1, 3, 5, 7, 8 };
            var rs7 = sayilar7.Where(s => s > 8).DefaultIfEmpty(5);
            foreach (var alan in rs7)
            { Response.Write(alan.ToString() + "<br>"); }
            //--------------------------------------------------------------


            // LINQ kullanarak dizinin elemanlarını sonda başa doğru yazdırdık.
            int[] sayilar8 = { 1, 5, 8, 159, 23, 17, 14, 24 };
            var sonuc = sayilar8.Reverse();
            foreach (var sayi in sonuc)
            { Response.Write(sayi + "<br>"); }
            //--------------------------------------------------------------


            // Veri Karşılaştırma
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "apple", "blueberry", "cherry" };
            bool match = wordsA.SequenceEqual(wordsB);
            Response.Write(match);

            var wordsA1 = new string[] { "cherry", "apple", "blueberry" };
            var wordsB1 = new string[] { "cherry", "apple", "blueberry" };
            bool match1 = wordsA1.SequenceEqual(wordsB1);
            Response.Write(match1);
            //--------------------------------------------------------------

            // dizinin, paramatre olarak girilen 2. dizi ile olan ortak elemanlarını listeler. iki tablo arasına aynı alanlar içinde aynı olan kayıtları gösterir
            int[] numbersA2 = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB2 = { 1, 3, 5, 7, 8 };
            var uniqueNumberse2 = numbersA2.Intersect(numbersB2);
            foreach (var n in uniqueNumberse2)
            { Response.Write(n); }
            //--------------------------------------------------------------

            // dizinin, parametre olarak girilen 2. dizide olmayan elemanlarını listeler.
            int[] numbersA1 = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB1 = { 1, 3, 5, 7, 8 };
            var uniqueNumberse1 = numbersA1.Except(numbersB1);
            foreach (var n in uniqueNumberse1)
            { Response.Write(n); }
            //--------------------------------------------------------------

            //Enumerable.Range(0, 100) 0 başlangıç değeri. 100 son değer
            var sayilara = from s in Enumerable.Range(0, 100) select new { Sayi = s, Sonuc = s % 2 == 0 ? "çift" : "Tek" };
            foreach (var sayi in sayilara)
            { Response.Write(String.Format("{0} {1}", sayi.Sayi, sayi.Sonuc) + "<br>"); }
            //--------------------------------------------------------------

            // koşula uygun ve Linq kullanırken bazen tür dönüşümleri yapmamız gerekir. Aşağıda  sadece string olanlar alınacaktır. OfType tür dönüşümü ve aşağıdaki sonuçta sayısal değer olsada hata vermez
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Adams");
            arrayList.Add("Arthur");
            arrayList.Add("Buchanan");
            arrayList.Add(12345);
            IEnumerable<string> names = arrayList.OfType<string>().Where(n => n.Length < 7);
            foreach (string name in names)
            { Response.Write(name + "<br>"); }

            // koşula uygun ve Linq kullanırken bazen tür dönüşümleri yapmamız gerekir. Aşağıda  sadece string olanlar alınacaktır. Cast tür dönüşümü ve aşağıdaki sonuçta sayısal değer olsada hata verir
            ArrayList arrayList1 = new ArrayList();
            arrayList1.Add("Adams");
            arrayList1.Add("Arthur");
            arrayList1.Add("Buchanan");
            IEnumerable<string> names1 = arrayList1.Cast<string>().Where(n => n.Length < 7);
            foreach (string name in names1)
            { Response.Write(name + "<br>"); }
            //--------------------------------------------------------------

        }
        //--------------------------------------------------------------------------------------------------------------------
    }
    */
    }
}
