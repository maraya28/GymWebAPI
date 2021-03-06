﻿using Models;
using System;

namespace ViewModels
{
    public class MemberViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public SeniorityType Seniority { get; set; }

        public MemberEntity ToEnity()
        {
            return new MemberEntity.Builder().SetFields(Id == default ? Guid.NewGuid() : Id,
                                                        Name,
                                                        BirthDate,
                                                        Seniority).Build();
        }


        public MemberEntity ToEnity(MemberEntity entity)
        {
            return new MemberEntity.Builder(entity).SetFields(Name,
                                                              BirthDate,
                                                              Seniority).Build();
        }

    }
}
