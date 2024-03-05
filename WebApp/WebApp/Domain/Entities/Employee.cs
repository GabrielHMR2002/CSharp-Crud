using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Enums;

namespace WebApp.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Status { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }




}
