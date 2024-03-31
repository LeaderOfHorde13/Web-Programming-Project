using Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.ContentModels
{
    public interface IContentRepository
    {
        public List<Content> GetAllContents();
        public List<Content> GetContentById(int contentId);
        public Content CreateContent(Content content);
        Content UpdateContent(Content content);
        public void DeleteContent(int contentId);

        public void IncreaseLike(int contentId);
        public void DiscreaseLike(int contentId);
        public void IncreaseComment(int contentId);
        public void DiscreaseComment(int contentId);
        public void IncreaseShare(int contentId);
        public void DiscreaseShare(int contentId);
        public void IncreaseJoining(int contentId);
        public void DiscreaseJoining(int contentId);
    }
}
