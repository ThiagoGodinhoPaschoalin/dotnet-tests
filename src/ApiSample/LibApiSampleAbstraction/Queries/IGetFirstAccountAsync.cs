using SharedDomain.Models;
using System;

namespace LibApiSampleAbstraction.Queries
{
    public interface IGetFirstAccountAsync : Interfaces.IQuery<Guid, AccountModel>
    { }
}