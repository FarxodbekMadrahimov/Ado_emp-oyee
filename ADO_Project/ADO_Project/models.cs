using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Project.Enums;
using ADO_Project.Interfaces;

namespace ADO_Project
{
    public class Empolyee : IData
    {
        public int Id { get; set ; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Status? Status { get; set; }
        public Role? Role { get; set; }       
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifyDate { get ; set ; }
        public DateTime DeletedDate { get; set; }
    }
}
