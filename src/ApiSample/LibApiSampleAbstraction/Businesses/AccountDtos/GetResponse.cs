using SharedDomain.Models;

namespace LibApiSampleAbstraction.Businesses.AccountDtos
{
    public class GetResponse
    {
        public GetResponse(AccountModel account)
        {
            Account = account;
        }

        public AccountModel Account { get; private set; }
    }
}