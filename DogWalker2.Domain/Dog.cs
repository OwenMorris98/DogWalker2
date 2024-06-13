using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Walks;

namespace DogWalker2.Domain
{
    public class Dog
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string? Notes { get; set; }

        public string customer_id { get; set; }

        [ForeignKey(nameof(customer_id))]
        public Customer Customer { get; set; }

        public ICollection<Walk> Walks { get; set; }

    }
}
