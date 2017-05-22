using AutoMapper;
using Cooking.Models.BindModels.Forum;
using Cooking.Models.EntityModels;
using Cooking.Models.ViewModels.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cooking.Web.Services
{
    public class ForumService:Service
    {
        public IEnumerable<ForumIndexViewModel> GetAllDiscussions()
        {
            IEnumerable<Discussion> discussions = this.Context.Discussions.ToList();

            IEnumerable<ForumIndexViewModel> vm = Mapper.Instance.Map<IEnumerable<Discussion>,
                                                                      IEnumerable<ForumIndexViewModel>>(discussions);

            return vm;
        }

        public DiscussonDetailsVm GetDiscussuonById(int id)
        {
            Discussion dis = this.Context.Discussions.FirstOrDefault(d => d.Id == id);
            DiscussonDetailsVm vm = Mapper.Instance.Map<Discussion, DiscussonDetailsVm>(dis);
            return vm;
        }

        internal IEnumerable<ForumIndexViewModel> CetDiscussionsFromSearch(string search)
        {
            IEnumerable<Discussion> discussions = this.Context.Discussions.Where(d => d.Title.Contains(search)).Select(d => d);

            IEnumerable<ForumIndexViewModel> vm = Mapper.Instance.Map<IEnumerable<Discussion>,
                                                                      IEnumerable<ForumIndexViewModel>>(discussions);

            return vm;
        }

        public void CreateDiscussion(CreateDiscussionBM bm, string userId)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == userId);
            Discussion discussion = new Discussion()
            {
                DateCreated = DateTime.Now,
                Description = bm.Description,
                Title = bm.Title,
                Creator =user
            };
            Context.Users.FirstOrDefault(u=>u.Id == userId);
            this.Context.Discussions.Add(discussion);
            this.Context.SaveChanges();
        }

        internal void CreatePost(MakePostBM bind, string userId)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == userId);
            Post post = new Post()
            {
                PostDate = DateTime.Now,
                Description = bind.Description,
                Title = bind.Title,
                Author = user
            };
            var discusson = this.Context.Discussions.FirstOrDefault(d=>d.Id==bind.Id);
            discusson.Posts.Add(post);
            this.Context.SaveChanges();
        }
    }
}