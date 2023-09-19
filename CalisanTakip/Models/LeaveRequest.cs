using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class LeaveRequest
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LeaveType { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? ApprovalStatus { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("LeaveRequests")]
        public virtual Employee? Employee { get; set; }
    }
}
