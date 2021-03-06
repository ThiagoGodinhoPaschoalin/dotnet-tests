using SharedDomain.BaseModels;
using System;

namespace SharedDomain.Models.Associative
{
    public class AccountProfile : AssociativeModel
    {
        private AccountProfile() : base() { }

        public AccountProfile(Guid profileId) 
            : base()
        {
            ProfileId = profileId;
        }

        public AccountProfile(Guid accountId, Guid profileId, Guid id)
            : this(profileId)
        {
            AccountId = accountId;
            Id = id;
        }

        public Guid AccountId { get; private set; }
        public Guid ProfileId { get; private set; }

        #region navigation
        public virtual AccountModel Account { get; set; }
        public virtual ProfileModel Profile { get; set; }
        #endregion
    }
}