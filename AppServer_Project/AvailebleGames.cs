namespace AppServer_Project
{
    public class AvailebleGames
    {
        private static readonly List<string> Games = new()
        {
           "Space Quest IV: Roger Wilco and the Time Rippers", "Steins;Gate", "Age of Wonders III: Golden Realms", 
            "Wizardry: Bane of the Cosmic Forge", "Darkest Dungeon: The Crimson Court", "Disco Elysium", "CrossCode", 
            "Persona Q2: New Cinema Labyrinth", "The Witch's House MV", "Epic Seven", "The Witcher 3: Wild Hunt - Complete Edition", 
            "Jungles of Maxtheria", "Animal Crossing: New Horizons - Happy Home Paradise", "Goat Simulator 3"
        };
        static public List<string> GetGames()
        {
            return Games;
        }

    }
}
