using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.DTOs
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Customers Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


        public byte MembershipTypeId { get; set; }

   
        //[Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }
    }
}