using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class Salary
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? SalaryAmount { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Salaries")]
        public virtual Employee? Employee { get; set; }
    }
}
