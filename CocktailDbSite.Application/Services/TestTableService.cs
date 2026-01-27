using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Models;

namespace CocktailDbSite.Application.Services;

public class TestTableService
{
    private readonly IRepository<TestTable> _testTableRepository;

    public TestTableService(IRepository<TestTable> testTableRepository)
    {
        _testTableRepository = testTableRepository;
    }

    public async Task<List<TestTable>> GetAllTestTablesAsync()
    {
        var testTables = await _testTableRepository.ListAsync();
        return testTables;
    }
}