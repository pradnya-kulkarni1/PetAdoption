using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PetAdoption.Models
{
    [Table("AdoptionRequest")]
    public class AdoptionRequest
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public int customerId { get; set; }

        [Required]
        public int referencePId { get; set; }

        [Required]
        public int referenceBId { get; set; }

        public DateTime SubmittedDate { get; set; }

        public string? Status {  get; set; }

        public string? RejectionReason { get; set; }

        public Boolean ReferenceCheck { get; set; }

        public Boolean BackgroundCheck { get; set; }

        public User? User { get; set; }
        public Customer? Customer { get; set; }
        public ReferencePersonal? ReferencePersonal {  get; set; }
        
        public ReferenceBackground? ReferenceBackground { get; set; }
        public List<Adoption>? Adoptions { get; set; }




    }
}


//create table adoptionRequest(
//id				int primary key identity(1,1),
//userId			int not null Constraint fk_adoptionRequest_user References [User] (id),
//customerId      int not null Constraint fk_adoptionRequest_customer References customer (id),
//referencePId	int not null constraint fk_adoptionRequest_referenceP References referencePersonal(id),
//referenceBId	int not null constraint fk_adoptionRequest_referenceB references referenceBackground(id),
//submittedDate	Date not null default Getdate(),
//status			varchar(10) not null default 'REVIEW',
//rejectionReason varchar(50),
//referenceCheck	bit not null,
//backgroundCheck	bit not null
//);
