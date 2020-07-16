﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Blazor.Shared.DTO
{
    public class EmployeeBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        public int? ReportsTo { get;  set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        [StringLength(70)]
        public string Address { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        [StringLength(40)]
        public string State { get; set; }
        [StringLength(40)]
        public string Country { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [StringLength(60)]
        public string Email { get; set; }
        public int CustomerCount { get;  set; }
        public int ReportsToCount { get;  set; }
        #endregion
    }
}
