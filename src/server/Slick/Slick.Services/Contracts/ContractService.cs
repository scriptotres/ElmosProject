using System;
using System.Collections.Generic;
using System.Linq;
using Slick.Models.Contracts;
using Slick.Repositories;

namespace Slick.Services.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IEntityRepository<Models.Contracts.Contract> repo;

        public ContractService(IEntityRepository<Models.Contracts.Contract> repo)
        {
            this.repo = repo;
        }
        public Models.Contracts.Contract Add(Models.Contracts.Contract c)
        {
            return repo.Add(c);
        }

        public void Delete(Models.Contracts.Contract c)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Contracts.Contract> GetActiveContract(Guid currentcontract)
        {
            return this.repo.FindBy(c=>c.Id==currentcontract).ToList() ;
        }
        public IEnumerable<Contract>GetContractForConsultants(Guid consultantId)
        {
            return this.repo.FindBy(c => c.ConsultantId == consultantId).ToList();
        }

        public IEnumerable<Models.Contracts.Contract> GetAll()
        {
            return repo.GetAllIncluding(c => c.ContractType).ToList();
        }

        public Models.Contracts.Contract GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(Models.Contracts.Contract c)
        {
            repo.Update(c);
        }
    }
}
