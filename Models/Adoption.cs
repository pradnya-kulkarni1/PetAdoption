using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoption.Models
{
    [Table("Adoption")]
    public class Adoption
    {
        [Key]
        public int Id { get; set; }

        public int AdoptRequestId { get; set; }
        public int PetId { get; set; }
        public DateTime AdoptionCompletedDate { get; set; }

        public Boolean PaymentDone { get; set; }
        public Boolean PaperworkDone { get; set; }

        public Pet? Pet { get; set; }
        public AdoptionRequest? AdoptionRequest { get; set; }

    }
}
/*
 * 
create table adoption(
id						int primary key identity(1,1),
adoptRequestId			int not null constraint fk_adoptionRequest_adoption references adoptionRequest(id),
petId					int not null constraint fk_adoption_pet references pet(id),
adoptionCompletedDate	date,
paymentDone				bit not null,
paperworkDone			bit not null
);
 */