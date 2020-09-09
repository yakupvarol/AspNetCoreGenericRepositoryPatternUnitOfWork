using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Helper
{
    public class LambdaSyntaxQuery
    {
        protected void Notlar()
        {
            // from x in Baglanti.db.Tbl_Kategorilers ---- x =>
            // select x ----- Select(x => x)
            // select new {x.id, x.Kategori}) ------ Select(x => new { x.id, x.Kategori })
            // where x.id>1 ----- Where(x => x.id > 1)
            // orderby x.Kategori ----- OrderBy(x=> x.Kategori)
        }
        //-------------------------------------------------

        /*
        protected void SelectFonksiyonu()
        {
            //Query Syntax
            //var rs = from x in Baglanti.db.Tbl_Kategorilers;

            //Lambda Syntax
            var rs = Baglanti.db.Tbl_Kategorilers.Select(x => x);
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //-----------------------------------------------------------------------------

            //Query Syntax
            //var rsn = (from x in Baglanti.db.Tbl_Kategorilers select new {x.id, x.Kategori}).ToList();

            //Lambda Syntax
            var rsn = Baglanti.db.Tbl_Kategorilers.Select(x => new { x.id, x.Kategori }).ToList();
            foreach (var alan in rsn)
            { Response.Write(alan.Kategori + "<br>"); }
            //-----------------------------------------------------------------------------

            //Query Syntax
            //var rsn = (from x in Baglanti.db.Tbl_Kategorilers where x.id>1 select new {x.id, x.Kategori}).ToList();

            //Lambda Syntax
            rsn = Baglanti.db.Tbl_Kategorilers.Where(x => x.id > 1).Select(x => new { x.id, x.Kategori }).ToList();
            foreach (var alan in rsn)
            { Response.Write(alan.Kategori + "<br>"); }
            //-----------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void WhereFonksiyonu()
        {
            //Query Syntax
            //var rs = (from x in Baglanti.db.Tbl_Kategorilers where x.id==1 select x).ToList();

            //Lambda Syntax
            var rs = Baglanti.db.Tbl_Kategorilers.Where(x => x.id == 1).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //-----------------------------------------------------------------------------

            //Query Syntax
            //rs = (from x in Baglanti.db.Tbl_Kategorilers where x.Kategori.Contains("saat") select x).ToList();

            //Lambda Syntax
            rs = Baglanti.db.Tbl_Kategorilers.Where(x => x.Kategori.Contains("saat")).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //-----------------------------------------------------------------------------

        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void OrderByFonksiyonu()
        {
            //Query Syntax
            //var rs = (from x in Baglanti.db.Tbl_Kategorilers where x.id==1 orderby x.Kategori select x).ToList();

            //Lambda Syntax order by Kategori asc
            var rs = Baglanti.db.Tbl_Kategorilers.Where(x => x.id > 1).OrderBy(x => x.Kategori).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

            //Lambda Syntax order by Kategori desc
            rs = Baglanti.db.Tbl_Kategorilers.Where(x => x.id > 1).OrderBy(x => x.Kategori).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

            //Lambda Syntax order by Kategori asc, Sira Asc
            rs = Baglanti.db.Tbl_Kategorilers.Where(x => x.id > 1).OrderBy(x => x.Kategori).ThenBy(x => x.Sira).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

            //Lambda Syntax order by Kategori desc, Sira desc
            rs = Baglanti.db.Tbl_Kategorilers.Where(x => x.id > 1).OrderBy(x => x.Kategori).ThenByDescending(x => x.Sira).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }

            //-----------------------------------------------------------------------------------

            //Query Syntax
            //var rsq = (from x in Baglanti.db.Tbl_Kategorilers where x.id == 1 select new { x.id, x.Kategori}).ToList();

            //Lambda Syntax order by Kategori asc
            var rsq = Baglanti.db.Tbl_Kategorilers.Where(x => x.id > 1).OrderBy(x => x.Kategori).Select(x => new { x.id, x.Kategori }).ToList();
            foreach (var alan in rsq)
            { Response.Write(alan.Kategori + "<br>"); }
        }
        //--------------------------------------------------------------------------------------------------------------------

        protected void DigerFonksiyonlar()
        {
            //Query Syntax
            //var rs = (from x in Baglanti.db.Tbl_Kategorilers where x.id==1 orderby x.Kategori select x).Take(2);

            //Lambda Syntax order by Kategori asc
            var rs = Baglanti.db.Tbl_Kategorilers.OrderBy(x => x.Kategori).Take(2);
            foreach (var alan in rs)
            { Response.Write(alan.Kategori + "<br>"); }
            //--------------------------------------------------------------------------------------------------------------------

        }
        //-------------------------------------------------

        protected void JoinFonksiyonlari()
        {
            //Query Syntax
            var rs = (from x in Baglanti.db.Tbl_Kategorilers join y in Baglanti.db.Tbl_Kayitlars on x.id equals y.CatID select new { y.Baslik }).ToList();
            foreach (var alan in rs)
            { Response.Write(alan.Baslik + "<br>"); }

            //Lambda Syntax
            var rsl = Baglanti.db.Tbl_Kategorilers.Join(Baglanti.db.Tbl_Kayitlars, x => x.id, y => y.CatID, (x, y) => new { x.Kategori, y.Baslik });
            foreach (var alan in rsl)
            { Response.Write(alan.Baslik + "<br>"); }
            //----------------------------------------------------------------------------------------    


            //Query Syntax
            var joinwhere = (from x in Baglanti.db.Tbl_Kategorilers join y in Baglanti.db.Tbl_Kayitlars on x.id equals y.CatID where x.Kategori.Contains("a") select new { y.Baslik }).ToList();
            foreach (var alan in joinwhere)
            { Response.Write(alan.Baslik + "<br>"); }

            //Lambda Syntax
            var rsf = Baglanti.db.Tbl_Kategorilers.Where(x => x.Kategori.Contains("a")).Join(Baglanti.db.Tbl_Kayitlars, x => x.id, y => y.CatID, (x, y) => new { x.Kategori, y.Baslik });
            foreach (var alan in rsf)
            { Response.Write(alan.Baslik + "<br>"); }
            //----------------------------------------------------------------------------------------    

            //----------------------------------------------------------------------------------------

        }
    }
    */
    }
}
