using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryRepositoryContainer : IRepositoryContainer
    {
       
        private readonly MemoryDataSource _dataSource;

        public MemoryRepositoryContainer(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public IPersonRepository PersonRepository
        {
            get { return new MemoryPersonRepository(_dataSource); }
        }
    }
}
