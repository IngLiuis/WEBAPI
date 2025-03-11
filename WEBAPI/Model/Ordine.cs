using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Model
{
    public class Ordine
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("data_inserimento")]
        public DateTime DataInserimento { get; set; }

        [Column("data_conferma_pdv")]
        public DateTime? DataConfermaPdv { get; set; }

        [Column("data_conferma_alloc")]
        public DateTime? DataConfermaAlloc { get; set; }

        [Column("magazzino")]
        [Required]
        public int Magazzino { get; set; }

        [Column("stato")]
        [Required]
        public int? Stato { get; set; }

        [Column("tipo")]
        [Required]
        public int? Tipo { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("bit")]
        public string Bit { get; set; }

        [Column("utente_inserimento")]
        public string? UtenteInserimento { get; set; }

        [Column("utente_conferma_pvd")]
        public string? UtenteConfermaPvd { get; set; }

        [Column("utente_conferma_alloc")]
        public string? UtenteConfermaAlloc { get; set; }

        [Column("ordine_da_importazione")]
        public int? OrdineDaImportazione { get; set; }

        [Column("data_inizio_preparazione")]
        public DateTime? DataInizioPreparazione { get; set; }

        [Column("utente_preparazione")]
        public string? UtentePreparazione { get; set; }

        [Column("data_spedizione")]
        public DateTime? DataSpedizione { get; set; }

        [Column("utente_spedizione")]
        public string? UtenteSpedizione { get; set; }

        [Column("data_importazione")]
        public DateTime? DataImportazione { get; set; }

        // Proprietà di navigazione
        public virtual ICollection<DettaglioOrdine> DettagliOrdine { get; set; }

    }
}
