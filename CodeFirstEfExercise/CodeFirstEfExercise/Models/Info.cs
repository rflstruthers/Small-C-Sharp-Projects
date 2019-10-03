using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEfExercise.Models
{
    public class Info
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InfoID { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        //The Adoptions property is a navigation property. 
        //A Info entity can be related to any number of Adoption entities.
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}