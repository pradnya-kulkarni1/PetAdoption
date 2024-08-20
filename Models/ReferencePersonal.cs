using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoption.Models
{
	[Table("ReferencePersonal")]
	public class ReferencePersonal
	{
		[Key]
		public int Id { get; set; }

		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string? phone { get; set; }

		public string? email { get; set; }

		public List<AdoptionRequest> AdoptionRequests { get; set; }

    }
}
/*
 * create table referencePersonal(
	id			int primary key identity(1,1),
	firstname	varchar(25),
	lastname	varchar(50),
	phone		varchar(12),
	email		varchar(75)
);
 */
