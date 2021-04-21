using SharedDomain.Models;
using System;

namespace LibApiSampleAbstraction.Queries
{
    public interface IGetFirstAccountWithProfilesAsync : Interfaces.IQuery<Guid, AccountModel>
    { }
}