using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class UserMapperAPI
    {
        public static UserBLL ToBLL(this UserAPI user)
        {
            return new UserBLL()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                //SaltKey = user.SaltKey,
                Rule = user.Rule,
                IdUser = user.IdUser,
            };
        }


        public static UserAPI ToAPI(this UserBLL user)
        {
            return new UserAPI()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                //SaltKey = user.SaltKey,
                Rule = user.Rule,
                IdUser = user.IdUser,

            };
        }

    }
}
