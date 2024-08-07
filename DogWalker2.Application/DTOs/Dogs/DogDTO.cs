using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Dogs
{
    public class DogDTO
    {

        public string Id { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string? Notes { get; set; }


        [JsonIgnore]
        public string? customer_id { get; set; }


    }


}
