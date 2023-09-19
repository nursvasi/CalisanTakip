using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalisanTakip.Models
{
    public partial class WorkHour
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? WorkDate { get; set; }
        public TimeSpan? EntryTime { get; set; }
        public TimeSpan? ExitTime { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("WorkHours")]
        public virtual Employee? Employee { get; set; }
    }
}
