using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class CustomerBE : BusinessEntity<Customer, int>,
        IAssignToBusinessEntity<EmployeeBE>
    {
        #region Public Properties
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(80)]
        public string Company { get; set; }
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
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
        public int? SupportRepId { get;  private set; }
        public int InvoiceCount { get; private set; }
        #endregion

        #region Constructors
        public CustomerBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion

        #region Public Methods
        public IEnumerable<InvoiceBE> GetInvoices()
        {
            var ids = Context.Invoice.Where(p => p.CustomerId == Id).Select(p => p.InvoiceId);

            foreach (var id in ids)
            {
                var item = new InvoiceBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }
        public void AddToInvoice(InvoiceBE invoice)
        {
            invoice.AssignTo(this);
        }

        public void AssignTo(EmployeeBE employee)
        {
            Entity.SupportRepId = employee.Id;
        }

        public override void Load(int id)
        {
            base.Load(id);

            FirstName = Entity.FirstName;
            LastName = Entity.LastName;
            Company = Entity.Company;
            Address = Entity.Address;
            City = Entity.City;
            State = Entity.State;
            Country = Entity.Country;
            PostalCode = Entity.PostalCode;
            Phone = Entity.Phone;
            Fax = Entity.Fax;
            Email = Entity.Email;
            SupportRepId = Entity.SupportRepId;
            InvoiceCount = Entity.Invoice.Count;
        }

        public override void Save()
        {
            Entity.FirstName = FirstName;
            Entity.LastName = LastName;
            Entity.Company = Company;
            Entity.Address = Address;
            Entity.City = City;
            Entity.State = State;
            Entity.Country = Country;
            Entity.PostalCode = PostalCode;
            Entity.Phone = Phone;
            Entity.Fax = Fax;
            Entity.Email = Email;
            Entity.SupportRepId = SupportRepId;
            base.Save();

            if (Id == default)
            {
                Id = Entity.CustomerId;
            }
        }

        public override string ToString()
        {
            return $"Customer Name:{FirstName} {LastName} Email:{Email}";
        }
        #endregion


    }
}
