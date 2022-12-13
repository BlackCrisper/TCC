using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_2._0.Models
{
    public class CATEGORIA
    {
        [Key]
        [Column("CATID")]
        [Display(Name = "CATID")]
        public int CATID { get; set; }

        [Column("CATDESCRICAO")]
        [Display(Name = "CATDESCRICAO")]
        public string? CATDESCRICAO { get; set; }
    }
}
