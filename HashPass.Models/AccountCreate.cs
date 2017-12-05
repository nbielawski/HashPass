using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Models
{
    public class AccountCreate
    {

        [Required]
        public string AcctName { get; set; }

        [Required]
        public string AcctPassword { get; set; }

        public override string ToString() => AcctName;
       

    }
}
