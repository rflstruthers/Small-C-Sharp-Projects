using System;
using System.Collections.Generic;

namespace CodeFirstEfExercise.Models
{
    public class Animal
    {
        //ID becomes the primary key in the table
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        //Navigation property
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}