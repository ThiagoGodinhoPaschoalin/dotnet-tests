using SharedDomain.Models;
using System;

namespace LibApiSampleAbstraction.Queries
{
    public interface IGetFirstProfileAsync : Interfaces.IQuery<Guid, ProfileModel>
    { }
}