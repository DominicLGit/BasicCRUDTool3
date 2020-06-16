using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using BasicCRUDTool3.Data;
using BasicCRUDTool3.Data.Models;

namespace BasicCRUDTool3.Business
{
    public abstract class BusinessEntity<TEntity, TKey> : ActiveRecord<TEntity, TKey> where TEntity : class, new()
    {
        #region Constructors
        protected BusinessEntity(ICRUDTestDBContextProvider cRUDTestDBContext) : base(cRUDTestDBContext)
        {
        }
        #endregion

        public virtual bool IsValid()
        {
            return IsValid(out _);
        }

        public virtual bool IsValid(out IEnumerable<ValidationResult> validationResults)
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, context, results, true) && OnValidate(results);

            validationResults = results;

            return isValid;
        }

        public override void Save()
        {
            if (!IsValid(out var results))
            {
                throw new ValidationException($"Entity was not saved because there are {results.Count()} validation errors.");
            }

            base.Save();
        }

        protected virtual bool OnValidate(ICollection<ValidationResult> results)
        {
            return !results.Any();
        }
    }
}
