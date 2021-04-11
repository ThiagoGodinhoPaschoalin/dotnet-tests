using SharedDomain.BaseModels;
using SharedDomain.Models.Associative;
using SharedDomain.Models.Enums;
using System;
using System.Collections.Generic;

namespace SharedDomain.Models
{
    public class AccountModel : EntityModel
    {
        private AccountModel() : base() { }

        public AccountModel(string firstName, string lastName, GenderType gender, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Document = document;
        }

        public AccountModel(string firstName, string lastName, GenderType gender, string document, Guid id)
            : this(firstName, lastName, gender, document)
        {
                Id = id;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string Document { get; set; }

        #region navigation

        public virtual ICollection<AccountProfile> Profiles { get; set; }

        #endregion
    }
}