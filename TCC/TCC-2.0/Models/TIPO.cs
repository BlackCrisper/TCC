using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TCC_2._0.Models
{
    public class TIPO
    {
        [Key]
        [Column("TIPID")]
        [Display(Name = "TIPID")]
        public int TIPID { get; set; }

        [Column("TIPNOME")]
        [Display(Name = "TIPNOME")]
        public string TIPNOME { get; set; }
    }
}
