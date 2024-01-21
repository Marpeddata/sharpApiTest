namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {

        //Jointable for many-to-many relationship
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
