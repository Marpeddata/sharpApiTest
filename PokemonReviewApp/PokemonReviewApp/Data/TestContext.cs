using System.Collections.Generic;


namespace PokemonReviewApp.Data
    
{
    public class TestContext
    {

        public List<String> dummyData { get; set; }



        public TestContext()
        {
            // Initialize the dummyData list with values.
            dummyData = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                dummyData.Add(i.ToString());
            }
        }
    }
}
