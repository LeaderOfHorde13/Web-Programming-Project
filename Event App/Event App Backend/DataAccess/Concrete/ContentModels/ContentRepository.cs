using DataAccess.Abstract.ContentModels;
using Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ContentModels
{
    public class ContentRepository : IContentRepository
    {
        public EventAppDbContext _context;

        public ContentRepository()
        {
            _context = new EventAppDbContext();
        }

        public Content CreateContent(Content content)
        {
            _context.Contents.Add(content);
            _context.SaveChanges();
            return content;
        }

        public void DeleteContent(int contentId)
        {
            var deletedItem = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            _context.Contents.Remove(deletedItem);
            _context.SaveChanges();
        }

        public List<Content> GetAllContents()
        {
            return _context.Contents.ToList();
        }

        public List<Content> GetContentById(int contentId)
        {
            return _context.Contents.Where(x => x.Id == contentId).ToList();
        }

        public Content UpdateContent(Content content)
        {
            _context.Contents.Update(content);
            _context.SaveChanges();
            return content;
        }

        public void IncreaseLike(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.LikeCounter += 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void DiscreaseLike(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.LikeCounter -= 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void IncreaseComment(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.CommentCounter += 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void DiscreaseComment(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.CommentCounter -= 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void IncreaseShare(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.ShareCounter += 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void DiscreaseShare(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.ShareCounter -= 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void IncreaseJoining(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.ParticipantCounter += 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }

        public void DiscreaseJoining(int contentId)
        {
            var content = _context.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            content.ParticipantCounter -= 1;

            _context.Contents.Update(content);
            _context.SaveChanges();
        }
    }
}
