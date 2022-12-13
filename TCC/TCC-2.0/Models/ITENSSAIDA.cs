using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_2._0.Models
{
    public class ITENSSAIDA
    {
        [Key]
        [Column("ITSID")]
        [Display(Name = "ITSID")]
        public int ITSID { get; set; }

        public SAIDA SAIDA { get; set; }
        [ForeignKey("SAIDA")]
        public int SAIID { get; set; }

        public PROTIPO PROTIPO { get; set; }
        [ForeignKey("PROTIPO")]
        public int PTID { get; set; }

        [Column("ITSQUANTIDADE")]
        [Display(Name = "ITSQUANTIDADE")]
        public int ITSQUANTIDADE { get; set; }

        [Column("ITSPRECO")]
        [Display(Name = "ITSPRECO")]
        public int ITSPRECO { get; set; }

   
    }
}
