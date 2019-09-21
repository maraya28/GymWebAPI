using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services.Test
{
    [TestClass]
    public class MemberServiceTest : TestBaseClass<MemberService>
    {
        protected Mock<IRepository<MemberEntity>> _members;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _members = new Mock<IRepository<MemberEntity>>();
            Target = new MemberService(_members.Object);
        }

        [TestClass]
        public class ValidateMember_Method : MemberServiceTest
        {
            [TestMethod]
            public void The_input_member_exist()
            {
                var results = new List<MemberEntity>()
                {
                    new MemberEntity.Builder().SetFields(Guid.Parse("C56A4180-65AA-42EC-A945-5FD21DEC0538"),
                                                         "Carlos Segura",
                                                          new DateTime(1986,06,12),
                                                          SeniorityType.Junior).Build()
                };
                _members.Setup(_ => _.GetAll()).Returns(results);

                var id = Guid.Parse("C56A4180-65AA-42EC-A945-5FD21DEC0538");
                Target.ValidateMember(id);
            }

            [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
            public void The_input_member_does_not_exist()
            {
                var results = new List<MemberEntity>()
                {
                    new MemberEntity.Builder().SetFields(Guid.Parse("C56A4180-65AA-42EC-A945-5FD21DEC0538"),
                                                         "Carlos Segura",
                                                          new DateTime(1986,06,12),
                                                          SeniorityType.Junior).Build(),

                    new MemberEntity.Builder().SetFields(Guid.Parse("C56A4180-65AA-42EC-A945-5FD21DEC0538"),
                                                         "Fernando Colomo",
                                                          new DateTime(1977,03,20),
                                                          SeniorityType.Senior).Build()
                };
                _members.Setup(_ => _.GetAll()).Returns(results);

                var id = Guid.Parse("293A5564-E2A0-4840-8D3C-C243DA1B1A8B");
                Target.ValidateMember(id);
            }

            [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
            public void It_throws_an_error_when_there_is_no_members_loaded()
            {
                _members.Setup(_ => _.GetAll()).Returns(default(List<MemberEntity>));
                var id = Guid.Parse("C56A4180-65AA-42EC-A945-5FD21DEC0538");

                Target.ValidateMember(id);
            }
        }
    }
}
