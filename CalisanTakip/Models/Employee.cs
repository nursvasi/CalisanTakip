using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
            LeaveRequests = new HashSet<LeaveRequest>();
            Salaries = new HashSet<Salary>();
            WorkHours = new HashSet<WorkHour>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Gender { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Position { get; set; }
        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDateW { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDateW { get; set; }
        [Unicode(false)]
        public string? Photograph { get; set; }
        [NotMapped]
        [DisplayName("Upload Image File")]
        public IFormFile ImageFile { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Employees")]
        public virtual Department? Department { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Salary> Salaries { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<WorkHour> WorkHours { get; set; }
    }
}
