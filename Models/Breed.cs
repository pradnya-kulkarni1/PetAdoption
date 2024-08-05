using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoption.Models
{
    [Table("Breed")]
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        public int SpeciesId { get; set; }
        public string name {  get; set; }

        public Species? Species { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
/*
 * 
create table breed(
id			int primary key identity(1,1),
speciesId	int not null constraint fk_breed_species references species(id),
name		varchar(75)
);
 */
