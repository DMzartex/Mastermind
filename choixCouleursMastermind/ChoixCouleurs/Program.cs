using System;

namespace choixCouleurs
{
    class Program
    {
        public static void choixCouleurs(out string[] colors, out string[] combi)
        {
            // TABLEAU COLORS
            colors = new string[6] { "rouge", "jaune", "orange", "bleu", "mauve", "rose" };
            combi = new string[4];
            Random rnd = new Random();

            for (int n = 0; n < combi.Length; n++)
            {
                int nombre = rnd.Next(0, 5);
                combi[n] = colors[nombre];
            }

        }

        public static void afficher( string[] combi)
        {
           
            for (int n = 0; n < combi.Length; n++)
            {
                Console.WriteLine(combi[n]);
            }
        }

        // Fonction choix des couleurs pour le joueur 
        public static void couleursjoueurs(ref string[] colorsJoueur, out string resultatColorsJoueur)
        {

           resultatColorsJoueur = "";
           for(int n = 0; n < 4; n++)
            {
                Console.WriteLine($"Entrez votre couleur n°{n}");
                colorsJoueur[n] = Console.ReadLine();
            }

            for(int n = 0; n < 4; n++)
            {
                resultatColorsJoueur = resultatColorsJoueur+ "," + colorsJoueur[n];
            }

            Console.WriteLine(resultatColorsJoueur);
            
        }
        static void Main(string[] args)
        {
            
            string[] colors;
            string[] combi;
            string[] colorsJoueur = new string[4];
            string resultatColorsJoueur;
            choixCouleurs(out colors, out combi);
            couleursjoueurs(ref colorsJoueur, out resultatColorsJoueur);
            Console.ReadLine();
        }
    }
}
