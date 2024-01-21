namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {

        //Jointable for many-to-many relationship
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
