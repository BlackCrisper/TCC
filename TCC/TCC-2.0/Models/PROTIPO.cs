using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TCC_2._0.Models
{
    public class PROTIPO
    {
        [Key]
        [Column("PTID")]
        [Display(Name = "PTID")]
        public int PTID { get; set; }

        public PRODUTO? PRODUTO { get; set; }
        [ForeignKey("PRODUTO")]
        public int PROID { get; set; }

        public TIPO? TIPO { get; set; }
        [ForeignKey("TIPO")]
        public int? TIPID { get; set; }

        [Column("PTMINIMO")]
        [Display(Name = "PTMINIMO")]
        public int PTMINIMO { get; set; }

        [Column("PTMAXIMO")]
        [Display(Name = "PTMAXIMO")]
        public int PTMAXIMO { get; set; }

        [Column("PTESTOQUE")]
        [Display(Name = "PTESTOQUE")]
        public int PTESTOQUE { get; set; }

        [Column("PTIMAGEM")]
        [Display(Name = "PTIMAGEM")]
        public byte[]? PTIMAGEM { get; set; }
    }
}
