using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Standard
    {
        [Key]
        public int Id { get; set; }
        public string standard { get; set; }

    }
}
