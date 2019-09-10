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
        private readonly IEntityRepository<ContractType> typerepo;

        public ContractService(IEntityRepository<Models.Contracts.Contract> repo,IEntityRepository<ContractType> typerepo)
        {
            this.repo = repo;
            this.typerepo = typerepo;
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

             return this.repo.FindBy(c => c.ConsultantId == consultantId).OrderBy(c=>c.StartDate).ToList();
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
            var type = c.ContractType;
            var t = new ContractType()
            {
                Id = type.Id,
                Title = type.Title
            };

            typerepo.Update(t);
            repo.Update(c);
        }
    }
}
