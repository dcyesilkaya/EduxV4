using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class PositivenessService : IPositivenessService
    {
        private readonly IRepository<Positiveness> positivenessRepository;
        public PositivenessService(IRepository<Positiveness> positivenessRepository)
        {
            this.positivenessRepository = positivenessRepository;
        }
        public void DeletePositiveness(string id)
        {
            Positiveness positiveness = GetPositiveness(id);
            positivenessRepository.Remove(positiveness);
            positivenessRepository.SaveChanges();
        }

        public IEnumerable<Positiveness> GetPositiveness()
        {
            return positivenessRepository.GetAll();
        }

        public Positiveness GetPositiveness(string id)
        {
            return positivenessRepository.Get(id);
        }

        public void InsertPositiveness(Positiveness positiveness)
        {
            positivenessRepository.Insert(positiveness);
        }

        public void UpdatePositiveness(Positiveness positiveness)
        {
            positivenessRepository.Update(positiveness);
        }
    }


    public interface IPositivenessService
        {
            IEnumerable<Positiveness> GetPositiveness();
            Positiveness GetPositiveness(string id);
            void InsertPositiveness(Positiveness positiveness);
            void UpdatePositiveness(Positiveness positiveness);
            void DeletePositiveness(string id);


        }

    
}
