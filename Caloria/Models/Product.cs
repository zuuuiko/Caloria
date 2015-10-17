using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caloria.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calorie { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydrate { get; set; }
    }
}