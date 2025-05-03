using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_SkillTree.Models;

public partial class AccountBook 

{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "{0}為必填欄位")]
    [Display(Name = "類型")]
    [Column("Categoryyy")]
    public int Type { get; set; }

    [Column("Amounttt")]
    [Display(Name = "金額")]
    [Required(ErrorMessage = "{0}為必填欄位")]
    public int Price { get; set; }

    [Column("Dateee")]
    [Display(Name = "日期")]
    [Required(ErrorMessage = "{0}為必填欄位")]
    public DateTime CreateDate { get; set; }

    [Column("Remarkkk")]
    public string Description { get; set; } = null!;
    public string TypeName => Type == 0 ? "收入" : "支出";

}


