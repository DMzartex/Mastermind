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

            // La boucle choisi aléatoirement 4 nombres à mettre dans le tableau combi
            for (int n = 0; n < combi.Length; n++)
            {
                int nombre = rnd.Next(0, 5);
                combi[n] = colors[nombre];
            }

        }

        // Création d'un clone pour la combinaison choisi par l'ordinateur
        public static void cloneCombiArray(string[] combi, out string[] cloneCombi)
        {
            // Tableau cloneCombi 
            cloneCombi = new string[4];

            // Boucle qui créé le tableau cloneCombi
            for (int i = 0; i < 4; i++)
            {
                cloneCombi[i] = combi[i];
            }
        }


        public static void afficher(string[]combi)
        {
           
            for (int n = 0; n < combi.Length; n++)
            {
                Console.WriteLine(combi[n]);
            }
        }

        // Fonction choix des couleurs pour le joueur 
        public static void couleursjoueurs(ref string[] colorsJoueur, out string resultatColorsJoueur)
        {
           // Résultat des couleurs entrer par le joueur sous forme de string 
           resultatColorsJoueur = "";
            string a;
           // Boucle qui permet au joueur de choisir 4 couleurs
           for(int n = 0; n < 4; n++)
            {
                int number;
                // Verification que l'utilisateur rentre bien une valeur
                do
                {   
                    Console.WriteLine($"Entrez votre couleur n°{n}");
                    colorsJoueur[n] = Console.ReadLine();

                } while (colorsJoueur[n] == "" || int.TryParse(colorsJoueur[n],out number));
            }

            // Boucle qui affiche les couleurs choisi par le joueur
            for(int n = 0; n < 4; n++)
            {
                resultatColorsJoueur = resultatColorsJoueur+ "," + colorsJoueur[n];
            }

            Console.WriteLine(resultatColorsJoueur);
            
        }

        // Fonction qui compare les pions rouges
        public static void CompareRouge(string[] colorsJoueur, string[] cloneCombi, out string resultRouge, out int rouge)
        {
            // Variable pion rouge
            rouge = 0;

            // Boucle qui compare les couleurs choisi par le joueur avec les couleurs dans la combinaison de l'ordinateur
            for (int i = 0; i < 4; i++)
            {   
                if (colorsJoueur[i] == cloneCombi[i])
                {
                    rouge = rouge + 1;
                    // Remplace la couleurs qui correspond à un pion rouge par * dans le tableau colorsJoueur
                    colorsJoueur[i] = "*";
                    // Remplace la couleurs qui correspond à un pion rouge par # dans le tableau cloneCombi
                    cloneCombi[i] = "#";
                }
            }
            // Affichage du nombre de pions rouges
            resultRouge = $"Languette(s) rouge : {rouge}";
            
        }
        
        // Fonction qui compare les pions blancs
        public static void compareBlanc(string[] colorsJoueur, string[] combi, out int blanc, out string resultBlanc)
        {
            // Variable pions blancs
            blanc = 0;
            // Boucle qui compare les couleurs choisi par le joueur avec les couleurs dans la combinaison de l'ordinateur
            for (int y = 0; y < 4; y++)
            {   
                for(int n = 0; n < 4; n++)
                {
                    if(colorsJoueur[y] == combi[n])
                    {
                        blanc = blanc + 1;
                        // Remplace la couleurs qui correspond à un pion rouge par / dans le tableau colorsJoueur
                        colorsJoueur[y] = "/";
                    }
                }

            }
            // Affichage du nombre de pions blancs
            resultBlanc = $"Languette(s) blanche : {blanc}";
        }
        

       public static void affichageTableau(string[] colorsJoueur, string[] combi,out string joueur, out string com)
        {
            joueur = "";
            com = "";
            
            for(int b = 0; b < 4; b++)
            {
                joueur = joueur + "-" +colorsJoueur[b];
                com = com +"-"+ combi[b];

            }

            Console.WriteLine(joueur);
            Console.WriteLine(com);

        }

        // Fonction qui affiche le message lorsque la partie est gagné
        public static void screenWin(int rouge,ref string restart, out string messageWinner)
        {
            // Message win
            messageWinner = "";
            
            // Condition pour que le joueur gagne
            if(rouge == 4)
            {
                Console.Clear();
                messageWinner = "Bravo vous avez gagnez !";
                // La variable restart prend comme valeur n pour empecher le joueur de réessayer si il a gagner
                restart = "n";
            }
            // Affichage du message win
            Console.WriteLine(messageWinner);
        }

       
    static void Main(string[] args)
        {
            string[] colors;
            string[] combi;
            string[] colorsJoueur = new string[4];
            string resultatColorsJoueur;
            string resultRouge;
            int rouge;
            int blanc;
            string resultBlanc;
            string joueur;
            string com;
            string restart = "y";
            string[] cloneCombi;
            string messageWinner;
            int b = 12;
            
            
            choixCouleurs(out colors, out combi);
            // Condition pour réessayer
            while (restart == "y" && b > 0)
            {   
                // Nombre de chance -1 à chaque tour
                b = b - 1;
                afficher(combi);
                couleursjoueurs(ref colorsJoueur, out resultatColorsJoueur);
                cloneCombiArray(combi, out cloneCombi);
                CompareRouge(colorsJoueur, cloneCombi, out resultRouge, out rouge);
                compareBlanc(colorsJoueur, combi, out blanc, out resultBlanc);
                affichageTableau(colorsJoueur, combi, out joueur, out com);
                Console.WriteLine(resultRouge);
                Console.WriteLine(resultBlanc);
                screenWin(rouge, ref restart, out messageWinner);
                // Condition pour avoir le message qui propose de réessayer qui s'affiche
                do
                {
                    if (b > 0)
                    {
                        Console.WriteLine("Voulez vous rejouez ? y/n");
                        restart = Console.ReadLine();
                    }
                } while (restart == "" || restart != "y" || restart != "n");

            }
            // Condition pour avoir le message de fin qui s'affiche
            if (b == 0)
            {
                Console.Clear();
                Console.WriteLine("Vous avez épuiser vos chances !");
            }
            if(restart == "n")
            {
                Console.Clear();
                Console.WriteLine("Fin de partie !");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Merci et à bientôt !");
            }
            Console.ReadLine();
        }
    }
}
