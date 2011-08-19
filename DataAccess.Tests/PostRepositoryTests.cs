using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataAccess.ColumnProvider.Concrete;
using DataAccess.Core.Concrete.Infrastructure;
using DataAccess.Entities;
using DataAccess.Mapping.Mappers;
using DataAccess.Param.Helpers.Concrete;
using DataAccess.Param.Repositories.Concrete;
using DataAccess.ParamCollection.Repositories.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using NUnit.Framework;

namespace DataAccess.Tests
{
    [TestFixture]
    public class PostRepositoryTests
    {
        private IPostRepository _repository;
        private IPersonRepository _personRepository;

        [TestFixtureSetUp]
        public void SetUp()
        {
            var dbFactory = new DatabaseFactory();

            var personColumnProvider = new PersonColumnProvider();
            var columnProvider = new PostColumnProvider();

            var personMapper = new PersonMapper(personColumnProvider);
            var mapper = new PostMapper(columnProvider, personMapper);

            var helper = new DataParamHelper();

            var paramRepository = new PostParamRepository(columnProvider, helper);
            var collectionRepository = new PostParamCollectionRepository(paramRepository);

            var personParamRepository = new PersonParamRepository(personColumnProvider, helper);
            var personCollectionRepository = new PersonParamCollectionRepository(personParamRepository);

            _repository = new PostRepository(dbFactory, mapper, collectionRepository);
            _personRepository = new PersonRepository(dbFactory, personMapper, personCollectionRepository);
        }

        [Test]
        public void GetPosts()
        {
            ICollection<Post> posts = _repository.GetAll();
            Assert.IsTrue(posts.Count > 0);
        }

        [Test]
        public void GetPostById()
        {
            Post post = _repository.GetById(1);
            Post post2 = _repository.GetById(2);
        }

        [Test]
        public void AddPost()
        {
            IList<Post> posts = new List<Post>();
            Person creator = _personRepository.GetById(1);

            for (int i = 0; i < 10; i++)
            {
                Post person = new Post
                {
                    Creator = creator,
                    Content = "blah" + i,
                    CreatedDateTime = DateTime.Now
                };
                posts.Add(person);
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            _repository.UnitOfWork.BeginTransaction();
            _repository.Add(posts);
            _repository.UnitOfWork.CommitTransaction();
            stopwatch.Stop();

            Console.WriteLine("Time Elapsed: " + stopwatch.Elapsed);
        }
    }
}
