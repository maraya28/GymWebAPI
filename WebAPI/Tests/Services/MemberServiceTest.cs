using GymWebAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using System.Threading.Tasks;
using GymWebAPI.Data;
using GymWebAPI.Models;

namespace GymWebAPI.Tests
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
        public class ValidateMemberMethod : MemberServiceTest
        {
            [TestMethod]
            public void The_input_member_Exist()
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
            public void It_throws_an_error_when_there_is_no_members_loaded()
            {
                _members.Setup(_ => _.GetAll()).Returns(default(List<MemberEntity>));
                var id = Guid.Parse("C56A4180-65AA-42EC-A945-5FD21DEC0538");

                Target.ValidateMember(id);
            }
        }

    }
}
