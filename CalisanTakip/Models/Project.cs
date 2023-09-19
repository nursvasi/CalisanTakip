using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? ProjectName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
