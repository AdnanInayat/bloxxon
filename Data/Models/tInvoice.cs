using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tInvoice")]
    public class tInvoice
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }

        public string Comments { get; set; }

        public DateTime Deadline { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual tUser User { get; set; }
        public virtual tCustomer Customer { get; set; }
    }
}
