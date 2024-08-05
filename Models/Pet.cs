using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoption.Models
{
    [Table("Pet")]
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public int BreedId { get; set; }

        public string Name { get; set; }
        public int Birthyear { get; set; }
        public int Birthmonth { get; set; }
        public string? PhotoPath { get; set; }
        public Breed? Breed { get; set; }
        public List<Adoption>? Adoptions { get; set; }
    }
}
/*
 * 
create table pet(
id			int primary key identity(1,1),
breedId		int not null constraint fk_pet_breed references breed(id),
name		varchar(75),
birthyear	int,
birthmonth	int,
photoPath	varchar(255)
);
 */
