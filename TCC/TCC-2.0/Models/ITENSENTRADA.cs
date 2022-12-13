
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_2._0.Models
{
    [Table("ITENSENTRADA")]
    public class ITENSENTRADA
    {
        [Key]
        [Column("ITEID")]
        [Display(Name = "ITEID")]
        public int ITEID { get; set; }

        public ENTRADA? ENTRADA { get; set; }
        [ForeignKey("ENTRADA")]
        public int ENTID { get; set; }

        public PROTIPO? PROTIPO { get; set; }
        [ForeignKey("PROTIPO")]
        public int PTID { get; set; }

        [Column("ITEQUANTIDADE")]
        [Display(Name = "ITEQUANTIDADE")]
        public int ITEQUANTIDADE { get; set; }

        [Column("ITEPRECO")]
        [Display(Name = "ITEPRECO")]
        public decimal ITEPRECO { get; set; }

    }
}
