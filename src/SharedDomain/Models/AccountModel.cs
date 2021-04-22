using SharedDomain.BaseModels;
using SharedDomain.Models.Associative;
using SharedDomain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedDomain.Models
{
    public class AccountModel : EntityModel
    {
        private AccountModel() : base() { }

        public AccountModel(string firstName, string lastName, GenderType gender, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Document = document;
            Email = email;
        }

        public AccountModel(string firstName, string lastName, GenderType gender, string document, string email, Guid id)
            : this(firstName, lastName, gender, document, email)
        {
                Id = id;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public GenderType Gender { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }

        public void AddProfiles(IEnumerable<Guid> profileIds)
        {
            if (profileIds is null) return;
            if (this.Profiles is null) Profiles = new List<AccountProfile>();
            IEnumerable<Guid> myProfileIds = this.Profiles.Select(x => x.ProfileId);
            
            var newAccountProfiles = profileIds
                .Where(newProfileId => !myProfileIds.Contains(newProfileId))
                .Select(newProfileId => new AccountProfile(newProfileId));

            foreach(var newProfile in newAccountProfiles)
            {
                this.Profiles.Add(newProfile);
            }
        }

        #region navigation

        public virtual ICollection<AccountProfile> Profiles { get; set; }

        #endregion
    }
}