using DataAccess.Abstract.Friend;
using Models.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Friend
{
    public class FollowingRepository : IFollowingRepository
    {
        public EventAppDbContext _context;

        public FollowingRepository()
        {
            _context = new EventAppDbContext();
        }

        public Follow CreateFollowing(Follow follow)
        {
            _context.Follows.Add(follow);
            _context.SaveChanges();
            return follow;
        }

        public void DeleteFollowing(int id)
        {
            var deletedItem = _context.Follows.Where(x => x.Id == id).FirstOrDefault();
            if (deletedItem != null)
            {
                _context.Follows.Remove(deletedItem);
                _context.SaveChanges();
            }
        }

        public List<Follow> GetAllFollows()
        {
            return _context.Follows.ToList();
        }

        public List<Follow> GetAllFollowsForNotification(int userId)
        {
            return _context.Follows.Where(x => x.ResponserId == userId).ToList();
        }

        public List<Follow> GetFollowingById(int requesterId, int responserId)
        {
            return _context.Follows.Where(x => x.RequesterId == requesterId && x.ResponserId == responserId).ToList();
        }

        public Follow UpdateFollowing(Follow follow)
        {
            _context.Follows.Update(follow);
            _context.SaveChanges();
            return follow;
        }
    }
}
