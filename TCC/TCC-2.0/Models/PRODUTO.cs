using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TCC_2._0.Models
{
    public class PRODUTO
    {
        [Key]
        [Column("PROID")]
        [Display(Name = "PROID")]
        public int PROID { get; set; }

        public CATEGORIA? CATEGORIA { get; set; }
        [ForeignKey("CATEGORIA")]
        public int CATID { get; set; }

        [Column("PRODESCRICAO")]
        [Display(Name = "PRODESCRICAO")]
        public string PRODESCRICAO { get; set; }

        [Column("PROIMAGEM")]
        [Display(Name = "PROIMAGEM")]
        public byte[]? PROIMAGEM { get; set; }
    }
}
