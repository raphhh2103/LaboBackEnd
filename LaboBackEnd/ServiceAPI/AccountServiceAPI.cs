using LaboBackEnd.MapperAPI;
using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;
using LaboBLL.ServicesBLL;

namespace LaboBackEnd.ServiceAPI
{
    public class AccountServiceAPI
    {
        private readonly UserServiceBLL _userServiceBLL;

        public AccountServiceAPI(UserServiceBLL  userSericeBLL)
        {
            this._userServiceBLL = userSericeBLL;
        }

        public UserBLL VerifyUser (UserAPI auth)
        {
            return _userServiceBLL.VerifyUser(auth.ToBLL());
        }

        public UserAPI GetOwnerCredentials(string credentialToVerify)
        {
            return _userServiceBLL.GetOwnerCredentials(credentialToVerify).ToAPI();
        }

    }
}
