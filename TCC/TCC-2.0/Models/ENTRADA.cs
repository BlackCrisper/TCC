using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_2._0.Models
{
    [Table("ENTRADA")]
    public class ENTRADA
    {
        [Key]
        [Column("ENTID")]
        [Display(Name = "ENTID")]
        public int ENTID { get; set; }

        [Column("ENTDATA")]
        [Display(Name = "ENTDATA")]
        public DateTime ENTDATA { get; set; }

        [Column("ENTORIGEM")]
        [Display(Name = "ENTORIGEM")]
        public string? ENTORIGEM { get; set; }

        [Column("ENTOBSERVACAO")]
        [Display(Name = "ENTOBSERVACAO")]
        public string? ENTOBSERVACAO { get; set; }

    }
}
