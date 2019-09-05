using Slick.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.Contracts
{
    public interface IContractService
    {
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetActiveContract(Guid contractid);
        Contract GetById(Guid id);
        void Update(Contract c);
        void Delete(Contract c);
        Contract Add(Contract c);
        IEnumerable<Contract> GetContractForConsultants(Guid consultantId);
    }
}
