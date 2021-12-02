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

        public static void cloneCombiArray(string[] combi, out string[] cloneCombi)
        {
            cloneCombi = new string[4];

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
        public static void CompareRouge(string[] colorsJoueur, string[] cloneCombi, out string resultRouge, out int rouge)
        {
            rouge = 0;

            for (int i = 0; i < 4; i++)
            {
                if (colorsJoueur[i] == cloneCombi[i])
                {
                    rouge = rouge + 1;
                    colorsJoueur[i] = "*";
                    cloneCombi[i] = "#";
                }
            }
            resultRouge = $"Languette(s) rouge : {rouge}";
            
        }

        public static void compareBlanc(string[] colorsJoueur, string[] combi, out int blanc, out string resultBlanc)
        {

            blanc = 0;

            for (int y = 0; y < 4; y++)
            {   
                for(int n = 0; n < 4; n++)
                {
                    if(colorsJoueur[y] == combi[n])
                    {
                        blanc = blanc + 1;
                        colorsJoueur[y] = "/";
                    }
                }

            }
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


        public static void screenWin(int rouge,ref string restart, out string messageWinner)
        {
            messageWinner = "";
   
            if(rouge == 4)
            {
                Console.Clear();
                messageWinner = "Bravo vous avez gagnez !";
                restart = "n";
            }
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
            int b = 2;
            
            
            choixCouleurs(out colors, out combi);
            while (restart == "y" && b >= 0)
            {
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
                if(restart == "y")
                {
                    Console.WriteLine("Voulez vous rejouez ? y/n");
                    restart = Console.ReadLine();
                }

                
            }
            if (b < 0)
            {
                Console.Clear();
                Console.WriteLine("Vous avez épuiser vos chances !");
            }
            Console.ReadLine();
        }
    }
}
