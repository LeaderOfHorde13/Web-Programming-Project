using Business.Abstract.Friend;
using DataAccess.Abstract.Friend;
using DataAccess.Concrete.Friend;
using Models.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Friend
{
    public class FollowingManager : IFollowingService
    {
        private IFollowingRepository _repository;
        public FollowingManager()
        {
            _repository = new FollowingRepository();
        }

        public Follow CreateFollowing(Follow follow)
        {
            return _repository.CreateFollowing(follow);
        }

        public void DeleteFollowing(int id)
        {
            _repository.DeleteFollowing(id);
        }

        public List<Follow> GetAllFollows()
        {
            return _repository.GetAllFollows();
        }

        public List<Follow> GetAllFollowsForNotification(int userId)
        {
            return _repository.GetAllFollowsForNotification(userId);
        }

        public List<Follow> GetFollowingById(int requesterId, int responserId)
        {
            return _repository.GetFollowingById(requesterId, responserId);
        }

        public Follow UpdateFollowing(Follow follow)
        {
            return _repository.UpdateFollowing(follow);
        }
    }
}
