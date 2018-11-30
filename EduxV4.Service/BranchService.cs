using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
   public class BranchService:IBranchService
    {
        private readonly IRepository<Branch> branchRepository;

        public BranchService(IRepository<Branch> branchRepository)
        {
            this.branchRepository = branchRepository;
        }
        public void DeleteBranch(string id)
        {
            Branch branch = GetBranch(id);
            branchRepository.Remove(branch);
            branchRepository.SaveChanges();
        }

        public Branch GetBranch(string id)
        {
            return branchRepository.Get(id);
        }

        public IEnumerable<Branch> GetBranches()
        {
            return branchRepository.GetAll();
        }

        public void InsertBranch(Branch branch)
        {
            branchRepository.Insert(branch);
        }

        public void UpdateBranch(Branch branch)
        {
            branchRepository.Update(branch);
        }
    }
    public interface IBranchService
    {
        IEnumerable<Branch> GetBranches();
        Branch GetBranch(string id);
        void InsertBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void DeleteBranch(string id);
    }
}
