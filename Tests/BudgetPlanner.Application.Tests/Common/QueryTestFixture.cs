using Application.Core;
using AutoMapper;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public IMapper mapper { get; private set; }
        public DataContext context { get; private set; }

        public QueryTestFixture()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            mapper = configurationProvider.CreateMapper();
            context = DataContextFactory.Create();
        }

        public void Dispose()
        {
            DataContextFactory.Destroy(context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    { }
}