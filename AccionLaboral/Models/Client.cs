﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccionLaboral.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int ClientId { get; set; }
        [Required]
        [Index(IsUnique=true)]
        [StringLength(10)]
        public string CorrelativeCode { get; set; }
        [Required]
        [Index("IX_ClientFirstNameLastName", 1, IsUnique = true)]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Index("IX_ClientFirstNameLastName", 2, IsUnique = true)]
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Neighborhood { get; set; }
        public string CompleteAddress { get; set; }
        public string Cellphone { get; set; }
        public string HomePhone { get; set; }
        public string Hobby { get; set; }
        public byte[] Photo { get; set; } 
        public string CurrentStudies { get; set; }
        public double WageAspiration { get; set; }
        public string FacebookEmail { get; set; }
        public string BBPin { get; set; }
        public string Twitter { get; set; }
        public string DesiredEmployment { get; set; }
        public string CompaniesWithPreviouslyRequested { get; set; }   
        public bool Approved { get; set; }
        public string  RejectionDesciption { get; set; }
        public int CurrentStateId { get; set; }
        public int CityId { get; set; }
        public int AdvisorId { get; set; }
        
        public State CurrentState { get; set; }
        public City City { get; set; }
        public Employee Advisor { get; set; }
        
        public ICollection <AcademicEducation> AcademicEducations { get; set; }
        public ICollection<KnownLanguage> Languages { get; set; }
        public ICollection<KnownProgram> KnownPrograms { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        public ICollection<Reference> References { get; set; }
        public ICollection<Tracking> Trackings { get; set; }
    }
}