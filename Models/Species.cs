using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public ICollection<Breed> Breed { get; set; }
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
