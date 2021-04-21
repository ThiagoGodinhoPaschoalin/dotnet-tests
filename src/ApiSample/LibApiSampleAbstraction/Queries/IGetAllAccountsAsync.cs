using SharedDomain.Models;
using System.Collections.Generic;

namespace LibApiSampleAbstraction.Queries
{
    public interface IGetAllAccountsAsync : Interfaces.IQueryOut<IEnumerable<AccountModel>>
    { }
}