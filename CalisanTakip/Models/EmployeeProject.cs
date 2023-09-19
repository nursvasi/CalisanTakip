using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class EmployeeProject
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Column("ProjectID")]
        public int? ProjectId { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeProjects")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey("ProjectId")]
        [InverseProperty("EmployeeProjects")]
        public virtual Project? Project { get; set; }
    }
}
