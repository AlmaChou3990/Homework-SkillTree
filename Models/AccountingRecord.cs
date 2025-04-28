using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public class AccountingRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Type { get; set; }

        public string TypeName => Type == "0" ? "收入" : "支出";
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
