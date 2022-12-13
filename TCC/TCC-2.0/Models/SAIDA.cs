using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_2._0.Models
{
    public class SAIDA
    {
        [Key]
        [Column("SAIID")]
        [Display(Name = "SAIID")]
        public int SAIID { get; set; }

        [Column("SAIDATA")]
        [Display(Name = "SAIDATA")]
        public DateTime SAIDATA { get; set; }
    }
}
