using GameEngine.Common.Entitys;
using GameEngine.Common;
using Microsoft.EntityFrameworkCore;

namespace Storage
{
    public class UserRepository : IUsersRepository
    {
        private readonly GameDataBaseContext context;

        public UserRepository(GameDataBaseContext context) 
        {
            this.context = context;
        }
        public async Task<ICollection<UserInfo>> GetUsers()
        {
            return await context.Set<UserInfo>().ToListAsync();
        }

        public Task<UserInfo> GetUser(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> Update(UserInfo userinfo)
        {
            throw new NotImplementedException();
        }
    }
}
