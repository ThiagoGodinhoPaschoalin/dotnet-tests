using SharedDomain.BaseModels;
using SharedDomain.Models.Associative;
using System;
using System.Collections.Generic;

namespace SharedDomain.Models
{
    public class ProfileModel : EntityModel
    {
        private ProfileModel() : base() { }

        public ProfileModel(string name)
            : base()
        {
            Name = name;
        }

        public ProfileModel(string name, Guid id)
            : this(name)
        {
            Id = id;
        }

        public string Name { get; private set; }

        #region navigation

        public virtual ICollection<AccountProfile> Accounts { get; set; }

        #endregion
    }
}