using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.ValidationAttributes
{
    public class CustomDateRangeAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly DateTime _maxDate;

        public CustomDateRangeAttribute()
        {
            _maxDate = DateTime.Today;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if ( dateValue > _maxDate)
                {
                    return new ValidationResult(ErrorMessage ?? "������o�W�L����");
                }
            }

            return ValidationResult.Success;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue.Date <= DateTime.Today;
            }
            return true;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-CustomDateRangeAttribute", ErrorMessage ?? "�u����v���o�j�󤵤�");
        }
    }
}
