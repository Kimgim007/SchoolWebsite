using EntityTest1.Entity;
using People.EntityTest1.Maping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1Context.Repository;

namespace EntityTest1.Service
{
    public class TeamService
    {
        private TeamRepository repository { get; set; } = new TeamRepository();

        public void Add(Team team)
        {
            this.repository.Add(Maping.map(team));
        }
        public Team Get(int id )
        {
            return Maping.map(this.repository.Get(id),true);
        }
        public List<Team> GetAll()
        {
            return this.repository.GetAll().Select(u=>Maping.map(u,true)).ToList();
        }
    }
}
