using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Models
{
    public class AccountDetail
    {
        public int AccountId { get; set; }

        public Guid OwnerId { get; set; }

        public string AcctName { get; set; }

        public string AcctPassword { get; set; }

        [Display(Name="Added")]
        public DateTimeOffset AddedUtc { get; set; }

        public DateTimeOffset? UpdatedUtc { get; set; }

        public override string ToString() => $"[{AccountId}] {AcctName}";
       
    }
}
