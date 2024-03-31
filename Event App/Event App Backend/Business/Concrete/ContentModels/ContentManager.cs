using Business.Abstract.ContentModels;
using DataAccess.Abstract.ContentModels;
using DataAccess.Concrete.ContentModels;
using Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ContentModels
{
    public class ContentManager : IContentService
    {
        public IContentRepository _repository;
        public ContentManager()
        {
            _repository = new ContentRepository();
        }
        public Content CreateContent(Content content)
        {
            return _repository.CreateContent(content);
        }

        public void DeleteContent(int contentId)
        {
            _repository.DeleteContent(contentId);
        }

        public List<Content> GetAllContents()
        {
            return _repository.GetAllContents();
        }

        public List<Content> GetContentById(int contentId)
        {
            return _repository.GetContentById(contentId);
        }

        public Content UpdateContent(Content content)
        {
            return _repository.UpdateContent(content);
        }

        public void IncreaseLike(int contentId)
        {
            _repository.IncreaseLike(contentId);
        }

        public void DiscreaseLike(int contentId)
        {
            _repository.DiscreaseLike(contentId);
        }

        public void IncreaseComment(int contentId)
        {
            _repository.IncreaseComment(contentId);
        }

        public void DiscreaseComment(int contentId)
        {
            _repository.DiscreaseComment(contentId);
        }

        public void IncreaseShare(int contentId)
        {
            _repository.IncreaseShare(contentId);
        }

        public void DiscreaseShare(int contentId)
        {
            _repository.DiscreaseShare(contentId);
        }

        public void IncreaseJoining(int contentId)
        {
            _repository.IncreaseJoining(contentId);
        }

        public void DiscreaseJoining(int contentId)
        {
            _repository.DiscreaseJoining(contentId);
        }
    }
}
