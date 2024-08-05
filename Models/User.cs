using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using PetAdoption.Models;

namespace PetAdoption.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<AdoptionRequest> AdoptionRequests { get; set; }

    }
}
//create table[user](
//	id			int primary key identity(1,1),
 //   firstname	varchar(25),
 //   lastname	varchar(25),
 //   phone		varchar(12),
 //   email		varchar(75),
  //  password	varchar(15) 
//);