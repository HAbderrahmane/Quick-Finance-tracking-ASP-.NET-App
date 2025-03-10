﻿using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class Expense  
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage ="amount needs to be verefied")]
        public double Amount { get; set; }
        [Required]
        public string Category { get; set; }= string.Empty;
        public DateTime Date { get; set; }= DateTime.Now;

    }
}
