using Models.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Friend
{
    public interface IFollowingRepository
    {
        public Follow CreateFollowing(Follow follow);
        public List<Follow> GetAllFollows();
        public List<Follow> GetFollowingById(int requesterId, int responserId);
        public Follow UpdateFollowing(Follow follow);
        public void DeleteFollowing(int id);
        public List<Follow> GetAllFollowsForNotification(int userId);
    }
}
