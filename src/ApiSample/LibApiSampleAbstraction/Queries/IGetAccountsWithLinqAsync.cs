using SharedDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibApiSampleAbstraction.Queries
{
    public interface IGetAccountsWithWhereLinqAsync 
        : Interfaces.IQuery<Expression<Func<AccountModel, bool>>, IEnumerable<AccountModel>>
    { }
}