using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    

        
    public class SeasonService : ISeasonService
        {
            private readonly IRepository<Season> seasonRepository;
            public SeasonService(IRepository<Season> seasonRepository)
            {
                this.seasonRepository = seasonRepository;
            }

            public void DeleteSeason(string id)
            {
                Season season = GetSeason(id);
                seasonRepository.Remove(season);
                seasonRepository.SaveChanges();
            }

            public Season GetSeason(string id)
            {
                return seasonRepository.Get(id);
            }

            public IEnumerable<Season> GetSeasons()
            {
                return seasonRepository.GetAll();
            }

            public void InsertSeason(Season season)
            {
                seasonRepository.Insert(season);
            }

            public void UpdateSeason(Season season)
            {
                seasonRepository.Update(season);
            }
        }

        public interface ISeasonService
        {
            IEnumerable<Season> GetSeasons();
            Season GetSeason(string id);
            void InsertSeason(Season season);
            void UpdateSeason(Season season);
            void DeleteSeason(string id);

        }
    }

































