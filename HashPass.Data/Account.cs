using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Data
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string AcctName { get; set; }

        [Required]
        public string AcctPassword { get; set; }

        [Required]
        public DateTimeOffset AddedUtc { get; set; }

        public DateTimeOffset UpdatedUtc { get; set; }


    }
}
