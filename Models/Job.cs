using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        [Key]
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please provide relevant salary")]
        public int Salary { get; set; }
    }
}