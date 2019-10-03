namespace CodeFirstEfExercise.Models
{
   
    public class Adoption
    {
        //AdoptionID will be primary key
        public int AdoptionID { get; set; }
        //InfoID is a foreign key, corresponding to Info
        public int InfoID { get; set; }
        //AnimalID is foreign key, corresponding to Animal
        public int AnimalID { get; set; }
        

        public virtual Info Info { get; set; }
        public virtual Animal Animal { get; set; }
    }
}