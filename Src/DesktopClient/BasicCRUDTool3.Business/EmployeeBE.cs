using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class EmployeeBE : BusinessEntity<Employee, int>,
         IAssignToBusinessEntity<EmployeeBE>
    {
        #region Public Properties
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        public int? ReportsTo { get; private set; }
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
        public int CustomerCount { get; private set; }
        public int ReportsToCount { get; private set; }
        #endregion

        #region Constructors
        public EmployeeBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion

        #region Public Methods
        public IEnumerable<CustomerBE> GetCustomers()
        {
            var ids = Context.Customer.Where(p => p.SupportRepId == Id).Select(p => p.CustomerId);

            foreach (var id in ids)
            {
                var item = new CustomerBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }

        public IEnumerable<EmployeeBE> GetReportsToThisEmployee()
        {
            var ids = Context.Employee.Where(p => p.ReportsTo == Id).Select(p => p.EmployeeId);

            foreach (var id in ids)
            {
                var item = new EmployeeBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }
        public void AddToCustomer(CustomerBE customer)
        {
            customer.AssignTo(this);
        }

        public void AddSubordinate (EmployeeBE employee)
        {
            employee.AssignTo(this);
        }
        public void AssignTo(EmployeeBE employee)
        {
            Entity.ReportsTo = employee.Id;
        }

        public override void Load(int id)
        {
            base.Load(id);

            FirstName = Entity.FirstName;
            LastName = Entity.LastName;
            Title = Entity.Title;
            ReportsTo = Entity.ReportsTo;
            BirthDate = Entity.BirthDate;
            HireDate = Entity.HireDate;
            Address = Entity.Address;
            City = Entity.City;
            State = Entity.State;
            Country = Entity.Country;
            PostalCode = Entity.PostalCode;
            Phone = Entity.Phone;
            Fax = Entity.Fax;
            Email = Entity.Email;
            ReportsToCount = Entity.InverseReportsToNavigation.Count;
            CustomerCount = Entity.Customer.Count;
        }

        public override void Save()
        {
            Entity.FirstName = FirstName;
            Entity.LastName = LastName;
            Entity.Title = Title;
            Entity.BirthDate = BirthDate;
            Entity.HireDate = HireDate;
            Entity.Address = Address;
            Entity.City = City;
            Entity.State = State;
            Entity.Country = Country;
            Entity.PostalCode = PostalCode;
            Entity.Phone = Phone;
            Entity.Fax = Fax;
            Entity.Email = Email;
            base.Save();

            if (Id == default)
            {
                Id = Entity.EmployeeId;
            }
        }

        public override string ToString()
        {
            return $"Employee Name:{FirstName} {LastName} Title:{Title}";
        }
        #endregion
    }
}
