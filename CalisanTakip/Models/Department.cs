using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? DepartmentName { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Description { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
