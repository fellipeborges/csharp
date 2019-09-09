using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureSearchPoC.Model;

namespace AzureSearchPoC.Management
{
    class LoaderMockedData
    {
        List<ContentModel> _contentModelList;

        public LoaderMockedData()
        {
            _contentModelList = new List<ContentModel>();
            LoadKBs();
            LoadTrainings();
        }

        public List<ContentModel> GetMockedData()
        {
            return _contentModelList;
        }

        private void LoadKBs()
        {
            _contentModelList.Add(new ContentModel { ContentId = "KB1", ContentType = ContentType.KB, Category = "Category A", HasVideo = 1, Tags = new string[] { "tag1", "tag2" }, Title = "KB Title 1", Description = "KB Description 1", Body = "KB Body 1" });
            _contentModelList.Add(new ContentModel { ContentId = "KB2", ContentType = ContentType.KB, Category = "Category A", HasVideo = 0, Tags = new string[] { "tag1", "tag3" }, Title = "KB Title 2", Description = "KB Description 2", Body = "KB Body 2" });
            _contentModelList.Add(new ContentModel { ContentId = "KB3", ContentType = ContentType.KB, Category = "Category A", HasVideo = 1, Title = "KB Title 3", Description = "KB Description 3", Body = "KB Body 3" });
            _contentModelList.Add(new ContentModel { ContentId = "KB4", ContentType = ContentType.KB, Category = "Category B", HasVideo = 0, Tags = new string[] { "tag1", "tag5" }, Title = "KB Title 4", Description = "KB Description 4", Body = "KB Body 4" });
            _contentModelList.Add(new ContentModel { ContentId = "KB5", ContentType = ContentType.KB, Category = "Category C", HasVideo = 1, Tags = new string[] { "tag2", "tag5" }, Title = "KB Title 5", Description = "KB Description 5", Body = "KB Body 5" });
        }
        private void LoadTrainings()
        {
            _contentModelList.Add(new ContentModel { ContentId = "TR1", ContentType = ContentType.Training, Category = "Category A", HasVideo = 0, Tags = new string[] { "tag2", "tag2" }, Title = "Training Title 1", Description = "Training Description 1", Body = "Training Body 1" });
            _contentModelList.Add(new ContentModel { ContentId = "TR2", ContentType = ContentType.Training, Category = "Category A", HasVideo = 0, Tags = new string[] { "tag1", "tag2" }, Title = "Training Title 2", Description = "Training Description 2", Body = "Training Body 2" });
            _contentModelList.Add(new ContentModel { ContentId = "TR3", ContentType = ContentType.Training, Category = "Category D", HasVideo = 0, Title = "Training Title 3", Description = "Training Description 3", Body = "Training Body 3" });
            _contentModelList.Add(new ContentModel { ContentId = "TR4", ContentType = ContentType.Training, Category = "Category E", HasVideo = 1, Tags = new string[] { "tag3", "tag4" }, Title = "Training Title 4", Description = "Training Description 4", Body = "Training Body 4" });
            _contentModelList.Add(new ContentModel { ContentId = "TR5", ContentType = ContentType.Training, Category = "Category A", HasVideo = 1, Tags = new string[] { "tag2", "tag4" }, Title = "Training Title 5", Description = "Training Description 5", Body = "Training Body 5" });
        }
    }
}
