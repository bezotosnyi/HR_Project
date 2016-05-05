﻿using Data.Infrastructure;
using Domain.DTO.DTOModels;
using Domain.Entities;
using Domain.Entities.Enum.Setup;
using Domain.Entities.Setup;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EFData.Extentions
{
    public static class VacancyExtensions
    {
        public static void Update(this Vacancy domain, VacancyDTO dto, IRepository<Level> levelrepo, IRepository<Location> locRepo, IRepository<Skill> skillRepo, IRepository<Tag> tagRepo)
        {
            domain.Id = dto.Id;
            domain.State = dto.State;

            domain.Title = dto.Title;
            domain.Description = dto.Title;
            domain.SalaryMin = dto.SalaryMin;
            domain.SalaryMax = dto.SalaryMax;
            domain.TypeOfEmployment = dto.TypeOfEmployment;
            domain.StartDate = dto.StartDate;
            domain.EndDate = dto.EndDate;
            domain.DeadlineDate = dto.DeadlineDate;

            domain.Levels = dto.LevelIds != null ? dto.LevelIds.Select(x => levelrepo.Get(x)).ToList() : domain.Levels;
            domain.Locations = domain.Locations != null ? dto.LocationIds.Select(x => locRepo.Get(x)).ToList() : domain.Locations;
            domain.RequiredSkills = domain.RequiredSkills != null ? dto.RequiredSkillIds.Select(x => skillRepo.Get(x)).ToList() : domain.RequiredSkills;
            domain.CandidatesProgress = dto.CandidatesProgress!=null ? dto.CandidatesProgress.Select(x => new VacancyStageInfo()
            {
                Id = x.Id,
                CandidateId = x.CandidateId,
                State = x.State,
                VacancyStage = new VacancyStage()
                {
                    Id = x.VacancyStage.Id,
                    StageId = x.VacancyStage.StageId,
                    Order = x.VacancyStage.Order,
                    IsCommentRequired = x.VacancyStage.IsCommentRequired,
                    State = x.VacancyStage.State,
                    VacancyId = x.VacancyStage.VacancyId,
                }
            }).ToList() : domain.CandidatesProgress;

            domain.Tags = domain.Tags != null ? dto.TagIds.Select(x => tagRepo.Get(x)).ToList() : domain.Tags;

            domain.ParentVacancyId = dto.ParentVacancyId;

            domain.IndustryId = dto.IndustryId;

            domain.DepartmentId = dto.DepartmentId;

            domain.ResponsibleId = dto.ResponsibleId;

            domain.LanguageSkill = dto.LanguageSkill != null ? new LanguageSkill()
            {
                LanguageId = dto.LanguageSkill.LanguageId,
                LanguageLevel = dto.LanguageSkill.LanguageLevel,
            } : domain.LanguageSkill;
        }
    }
}
