
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Data;

namespace PokemonReviewApp.Repository
{
    public class TestRepository : ITest
    {

        private readonly TestContext _context;
        public TestRepository(TestContext context)
        {
            _context = context;
        }

        public ICollection<string> GetTestData()
        {
            return _context.dummyData;
        }
    }
}
