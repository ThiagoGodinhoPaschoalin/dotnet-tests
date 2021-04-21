using SharedDomain.Models;
using System.Collections.Generic;

namespace LibApiSampleAbstraction.Queries
{
    public interface IGetAllProfilesAsync : Interfaces.IQueryOut<IEnumerable<ProfileModel>>
    { }
}