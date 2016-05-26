using NUnit.Framework;
using SharpRepository.Repository;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using SharpRepository.Tests.Integration.TestAttributes;
using SharpRepository.Tests.Integration.TestObjects;
using Should;

namespace SharpRepository.Tests.Integration
{
    [TestFixture]
    public class RepositoryFindTests : TestBase
    {
        [ExecuteForAllRepositories]
        public void Find_Should_Return_Single_Item_Which_Satisfies_Specification(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(new Specification<Contact>(p => p.Name == "Test User 1"));
            result.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_Single_Item_Which_Satisfies_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(p => p.Name == "Test User 1");
            result.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_Single_Item_Which_Satisfies_Composite_Specification(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(new Specification<Contact>(p => p.Name == "Test User 1").OrElse(new Specification<Contact>(p => p.Name == "Test User 1000")));
            result.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_Single_Item_Which_Satisfies_Composite_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(p => p.Name == "Test User 1" || p.Name == "Test User 1000");
            result.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_First_Ordered_Item_Which_Satisfies_Specification(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(new Specification<Contact>(p => p.Name.StartsWith("Test")), new SortingOptions<Contact>("Name", true));
            result.Name.ShouldEqual("Test User 3");

            var result2 = repository.Find(new Specification<Contact>(p => p.Name.StartsWith("Test")), new SortingOptions<Contact>("Name", false));
            result2.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_First_Ordered_Item_Which_Satisfies_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(p => p.Name.StartsWith("Test"), new SortingOptions<Contact>("Name", true));
            result.Name.ShouldEqual("Test User 3");

            var result2 = repository.Find(p => p.Name.StartsWith("Test"), new SortingOptions<Contact>("Name", false));
            result2.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_First_Ordered_Item_Which_Satisfies_Specification_WIth_Sorting_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(new Specification<Contact>(p => p.Name.StartsWith("Test")), new SortingOptions<Contact, string>(c => c.Name, true));
            result.Name.ShouldEqual("Test User 3");

            var result2 = repository.Find(new Specification<Contact>(p => p.Name.StartsWith("Test")), new SortingOptions<Contact, string>(c => c.Name, false));
            result2.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void Find_Should_Return_First_Ordered_Item_Which_Satisfies_Predicate_WIth_Sorting_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            var result = repository.Find(p => p.Name.StartsWith("Test"), new SortingOptions<Contact, string>(c => c.Name, true));
            result.Name.ShouldEqual("Test User 3");

            var result2 = repository.Find(p => p.Name.StartsWith("Test"), new SortingOptions<Contact, string>(c => c.Name, false));
            result2.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void TryFind_Should_Return_True_And_Single_Item_Which_Satisfies_Specification(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            Contact result;
            repository.TryFind(new Specification<Contact>(p => p.Name == "Test User 1"), out result).ShouldBeTrue();
            result.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void TryFind_Should_Return_True_And_Single_Item_Which_Satisfies_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            Contact result;
            repository.TryFind(p => p.Name == "Test User 1", out result).ShouldBeTrue();
            result.Name.ShouldEqual("Test User 1");
        }

        [ExecuteForAllRepositories]
        public void TryFind_Should_Return_True_Which_Satisfies_Specification(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            repository.Exists(new Specification<Contact>(p => p.Name == "Test User 1")).ShouldBeTrue();
        }

        [ExecuteForAllRepositories]
        public void TryFind_Should_Return_True_Which_Satisfies_Predicate(IRepository<Contact, string> repository)
        {
            for (var i = 1; i <= 3; i++)
            {
                var contact = new Contact { Name = "Test User " + i };
                repository.Add(contact);
            }

            repository.Exists(p => p.Name == "Test User 1").ShouldBeTrue();
        }

        [ExecuteForAllRepositories]
        public void TryFind_Should_Return_False_When_Predicate_Does_Not_Match(IRepository<Contact, string> repository)
        {
            repository.Exists(p => p.Name == "DOES NOT EXIST").ShouldBeFalse();
        }

        [ExecuteForAllRepositories]
        public void TryFind_Should_Return_False_When_Specification_Does_Not_Match(IRepository<Contact, string> repository)
        {
            repository.Exists(new Specification<Contact>(p => p.Name == "DOES NOT EXIST")).ShouldBeFalse();
        }
    }
}