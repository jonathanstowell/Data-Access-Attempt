using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataAccess.ColumnProvider.Concrete;
using DataAccess.Core.Concrete.Infrastructure;
using DataAccess.Entities;
using DataAccess.Mapping.Mappers;
using DataAccess.Param.Repositories.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using NUnit.Framework;

namespace DataAccess.Tests
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private IPersonRepository _repository;

        [TestFixtureSetUp]
        public void SetUp()
        {
            var dbFactory = new DatabaseFactory();
            var columnProvider = new PersonColumnProvider();
            var mapper = new PersonMapper(columnProvider);
            var paramRepository = new PersonParamRepository(columnProvider);
            var collectionRepository = new PersonParamCollectionRepository(paramRepository);

            _repository = new PersonRepository(dbFactory, mapper, collectionRepository);
        }

        [Test]
        public void GetPeople()
        {
            ICollection<Person> people = _repository.GetAll();
            Assert.IsTrue(people.Count > 0);
        }

        [Test]
        public void GetPersonById()
        {
            Person person = _repository.GetById(1);
            Person person2 = _repository.GetById(2);
        }

        [Test]
        public void AddPerson()
        {
            IList<Person> people = new List<Person>();

            for (int i = 0; i < 5000; i++)
            {
                Person person = new Person
                                    {
                                        Email = "blah" + i + "@fantasyleague.co.uk",
                                        FirstName = "blah" + i,
                                        LastName = "blah" + i
                                    };
                people.Add(person);
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            _repository.UnitOfWork.BeginTransaction();
            _repository.Add(people);
            _repository.UnitOfWork.CommitTransaction();
            stopwatch.Stop();

            Console.WriteLine("Time Elapsed: " + stopwatch.Elapsed);
        }

        [Test]
        public void UpdatePerson()
        {
            Person person = _repository.GetById(2);

            person.FirstName = "Blah";

            _repository.Update(person);
        }

        [Test]
        public void DeletePersonById()
        {
            Person person = _repository.GetById(1);
            _repository.Delete(person);
        }
    }
}
