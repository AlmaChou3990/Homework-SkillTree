using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homework_SkillTree.ValidationAttributes;

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
    //只能輸入正整數
    [Range(1, int.MaxValue, ErrorMessage = "{0}必須是正整數")]
    public int Price { get; set; }

    [Column("Dateee")]
    [Display(Name = "日期")]
    [Required(ErrorMessage = "{0}為必填欄位")]
    [DataType(DataType.Date)]
    [CustomDateRange(ErrorMessage = "「日期」不得大於今天")]
    public DateTime CreateDate { get; set; }

    [Column("Remarkkk")]
    [Display(Name = "備註")]
    [Required(ErrorMessage = "{0}為必填欄位")]
    [StringLength(100, ErrorMessage = "「{0}」最多輸入{1}個字元", MinimumLength = 0)]
    public string Description { get; set; } = null!;
    public string TypeName => Type == 0 ? "收入" : "支出";

}


