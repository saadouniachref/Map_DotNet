﻿using Domain;
using Map_DotNet.Data.Infrastructure;
using Service.Interfaces;
using Service.Services;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MandateService : Service<Mandate>, IMandateService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        private IRequestService rs = new RequestService();
        private IPersonService ps = new PersonService();
        private IProjectService pros = new ProjectService();
        public MandateService():base(uow)
        {

        }
        public void addSuggestion(request  r , person p)
        {
            request req = rs.GetById(r.id);
            req.suggessedResource_id = p.id;
            person pp = ps.GetById(p.id);
            pp.availability = "availableSoon";
            rs.Update(req);
            ps.Update(pp);
            rs.Commit();
            ps.Commit();
        }
        public request getRequestSortedByProjectSkills(int id)
        {
            request r = rs.GetById(id);
            var r1 = from name in r.project.projectskills
                     orderby name.percentage descending
                     select name;
            r.project.projectskills = new List<projectskill>();
            foreach(var i in r1)
            {
                r.project.projectskills.Add(i);
            }
            return r;
        }
    }
}
