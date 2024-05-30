using ETM.API.Repository.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ETM.API.Tests.Helpers
{
    public static class MemoryDataContext
    {
        public static DataContext GetMemoryDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            return new DataContext(options);
        }
    }
}
