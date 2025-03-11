using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WEBAPI.Model
{
    [Table("dettagli_ordine")]
    public class DettaglioOrdine
    {
        [Column("id_ordine")]
        [ForeignKey("Ordine")]
        public int IdOrdine { get; set; }

        [ Column("codarticolo")]
        [MaxLength(32)]
        public string CodArticolo { get; set; }

        [Column("nky_dep")]
        [MaxLength(3)]
        public string NkyDep { get; set; }

        [Column("suggerimento")]
        public int? Suggerimento { get; set; }

        [Column("qta_ord")]
        public int? QtaOrd { get; set; }

        [Column("qta_cli")]
        public int? QtaCli { get; set; }

        [Column("qta_rev")]
        public int? QtaRev { get; set; }

        [Column("qta_ven7")]
        public int? QtaVen7 { get; set; }

        [Column("qta_ven15")]
        public int? QtaVen15 { get; set; }

        [Column("giac_pdv")]
        public int? GiacPdv { get; set; }

        [Column("giac_sede")]
        public int? GiacSede { get; set; }

        [Column("fg")]
        [MaxLength(1)]
        public string Fg { get; set; }

        [Column("fp")]
        [MaxLength(1)]
        public string Fp { get; set; }

        [Column("STRIGA")]
        [MaxLength(4)]
        public string Striga { get; set; }

        [Column("Mag_ordine")]
        [MaxLength(3)]
        public string MagOrdine { get; set; }

        [Column("qta_sped")]
        public int? QtaSped { get; set; }

        [Column("Documento")]
        [MaxLength(40)]
        public string Documento { get; set; }

        [Column("cky_art_prezzo")]
        public decimal? CkyArtPrezzo { get; set; }

        // Proprietà di navigazione
        [JsonIgnore]
        public virtual Ordine Ordine { get; set; }


    }
}
