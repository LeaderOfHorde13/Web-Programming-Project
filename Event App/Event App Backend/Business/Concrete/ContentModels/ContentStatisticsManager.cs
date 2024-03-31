using Business.Abstract.ContentModels;
using DataAccess.Abstract.ContentModels;
using DataAccess.Concrete.ContentModels;
using DTO.ContentModels;
using Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ContentModels
{
    public class ContentStatisticsManager : IContentStatisticsService
    {
        public IContentStatisticsRepository _repository;
        public ContentStatisticsManager()
        {
            _repository = new ContentStatisticsRepository();
        }
        public ContentStatistics CreateContentStatistics(ContentStatistics contentStatistics)
        {
            return _repository.CreateContentStatistics(contentStatistics);
        }

        public void DeleteContentStatistics(int contentStatisticsId)
        {
            _repository.DeleteContentStatistics(contentStatisticsId);
        }

        public List<ContentStatistics> GetAllContentStatistics()
        {
            return _repository.GetAllContentStatistics();
        }

        public List<ContentStatistics> GetContentStatisticsById(int contentStatisticsId)
        {
            return _repository.GetContentStatisticsById(contentStatisticsId);
        }

        public ContentStatistics UpdateContentStatistics(ContentStatistics contentStatistics)
        {
            return _repository.UpdateContentStatistics(contentStatistics);
        }

        public List<CommentDto> GetAllComments(int contentId)
        {
            return _repository.GetAllComments(contentId);
        }

        public List<ContentComment> GetAllContentComments(int contentId)
        {
            return _repository.GetAllContentComments(contentId);
        }

        public ContentComment CreateComment(ContentComment contentComment)
        {
            return _repository.CreateComment(contentComment);
        }
    }
}
