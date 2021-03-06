﻿using Domain;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ResourceViewModel
    {
        public int id { get; set; }
        public SeniorityType seniority { get; set; }
        public WorkType workProfil { get; set; }
        public float salary { get; set; }
        public string picture { get; set; }
        public float moyenneSkill { get; set; }
        public JobType jobType { get; set; }
        public string cv { get; set; }
        public string businessSector { get; set; }
        public AvailibilityType availability { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int archived { get; set; }
        public List<resourceskill> resourceSkills { get; set; }
    }
}