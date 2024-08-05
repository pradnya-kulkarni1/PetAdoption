using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoption.Models
{
    [Table("Species")]
    public class Species
    {
        [Key]
        public int Id { get; set; }

        public string name  { get; set; }

        [Required]
        public decimal AdoptionFee { get; set; }

        public List<Breed>? Breeds { get; set; }
    }
}
/*
 * 
create table species(
id			int primary key identity(1,1),
name		varchar(75),
adoptionfee decimal(10,2) not null default 0,
);
 */
