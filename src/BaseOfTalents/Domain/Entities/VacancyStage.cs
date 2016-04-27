﻿using Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VacancyStage : BaseEntity
    {
        public int Order { get; set; }
        public bool IsCommentRequired { get; set; }

        public int VacancyId { get; set; }
        public virtual Vacancy Vacacny { get; set; }

        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
