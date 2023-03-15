using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonWeb.Models.Siniflar
{
    public class Kategori
    {
        public int KategoriId { get; set; }//üzerinde bulunan [key] ile birincil anahtar olduğunu belirttik.

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}