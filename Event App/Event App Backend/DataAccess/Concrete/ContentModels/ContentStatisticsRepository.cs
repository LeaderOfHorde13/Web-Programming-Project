using DataAccess.Abstract.ContentModels;
using DTO.ContentModels;
using Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ContentModels
{
    public class ContentStatisticsRepository : IContentStatisticsRepository
    {
        public EventAppDbContext _context;

        public ContentStatisticsRepository()
        {
            _context = new EventAppDbContext();
        }
        public ContentStatistics CreateContentStatistics(ContentStatistics contentStatistics)
        {
            _context.ContentStatistics.Add(contentStatistics);
            _context.SaveChanges();
            return contentStatistics;
        }

        public void DeleteContentStatistics(int contentStatisticsId)
        {
            var deletedItem = _context.ContentStatistics.Where(x => x.Id == contentStatisticsId).FirstOrDefault();
            _context.ContentStatistics.Remove(deletedItem);
            _context.SaveChanges();
        }

        public List<ContentStatistics> GetAllContentStatistics()
        {
            return _context.ContentStatistics.ToList();
        }

        public List<ContentStatistics> GetContentStatisticsById(int guestsId)
        {
            return _context.ContentStatistics.Where(x => x.GuestsId == guestsId).ToList();
        }

        public ContentStatistics UpdateContentStatistics(ContentStatistics contentStatistics)
        {
            //gID kID 
            var statistics = _context.ContentStatistics.Where(a => a.ContentId == contentStatistics.ContentId && a.GuestsId == contentStatistics.GuestsId)
                                                            .FirstOrDefault();
            statistics.Comment = contentStatistics.Comment;
            statistics.Content = contentStatistics.Content;
            statistics.ContentId = contentStatistics.ContentId;

            statistics.IsComment = contentStatistics.IsComment;
            statistics.IsChecked = contentStatistics.IsChecked;
            statistics.IsLiked = contentStatistics.IsLiked;
            statistics.IsShared = contentStatistics.IsShared;

            statistics.IsParticipate = contentStatistics.IsParticipate;
            statistics.GuestsId = contentStatistics.GuestsId;
            statistics.GuestUsername = contentStatistics.GuestUsername;

            statistics.Message = contentStatistics.Message;
            statistics.OwnerId = contentStatistics.OwnerId;

            _context.ContentStatistics.Update(statistics);
            _context.SaveChanges();
            return contentStatistics;
        }

        public List<CommentDto> GetAllComments(int contentId)
        {
            var statistics = _context.ContentStatistics.Where(x => x.ContentId == contentId).ToList();

            List<CommentDto> comments = new List<CommentDto>();

            foreach (var item in statistics)
            {
                CommentDto comment = new CommentDto();
                comment.Text = item.Comment;
                comment.SenderUsername = item.GuestUsername;

                comments.Add(comment);
            }

            return comments;

        }

        public List<ContentComment> GetAllContentComments(int contentId)
        {
            var comments = _context.ContentComments.Where(x => x.ContentId == contentId).ToList();

            return comments;
        }

        public ContentComment CreateComment(ContentComment contentComment)
        {
            _context.ContentComments.Add(contentComment);
            _context.SaveChanges();
            return contentComment;
        }
    }
}
