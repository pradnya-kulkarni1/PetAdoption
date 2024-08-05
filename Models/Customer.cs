using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoption.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }


    }
}
/*
 * create table customer(
id			int primary key identity(1,1),
firstname	varchar(50),
lastname	varchar(50),
phone		varchar(12),
email		varchar(75),
address		varchar(50),
city		varchar(50),
state		varchar(2),
zip			varchar(5)
);
 * 
 */