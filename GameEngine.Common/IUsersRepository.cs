using GameEngine.Common.Entitys;

namespace GameEngine.Common
{
    public interface IUsersRepository
    {
        Task<ICollection<UserInfo>> GetUsers();
        
        Task<UserInfo> GetUser(string name);

        Task<UserInfo> Update(UserInfo userinfo);
    }
}