using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teka
{
    class GameObjectAnime
    {
        public Rectangle position;
        public int vitesse;
        public Texture2D sprite;
        public bool estVivant;
        public Vector2 direction;
        public Rectangle spriteAffiche; // Le rectangle affiché à l'écran


        public enum Etat { AttenteHaut, AttenteBas, AttenteGauche, AttenteDroite, RunDroite, RunGauche, RunHaut, RunBas};
        public Etat etat;


        //competuer qui chargera le sprite afficher
        private int compteur = 0;

        //gestion tableau sprite
        int runState = 0; // etat de depart
        int nbEtatsRun = 4; // nb d etat de run (nb de rectangles)

        public Rectangle[] tabRunDroite =
        {
            new Rectangle(0,144,55,72),
            new Rectangle(55,144,55,72),
            new Rectangle(110,144,55,72),
            new Rectangle(165,144,55,72)
        };

        public Rectangle[] tabRunGauche =
        {
            new Rectangle(0,72,55,72),
            new Rectangle(55,72,55,72),
            new Rectangle(110,72,55,72),
            new Rectangle(165,72,55,72)
        };

        public Rectangle[] tabRunHaut =
        {
            new Rectangle(0,216,55,72),
            new Rectangle(55,216,55,72),
            new Rectangle(110,216,55,72),
            new Rectangle(165,216,55,72)
        };

        public Rectangle[] tabRunBas =
        {
            new Rectangle(0,0,55,72),
            new Rectangle(55,0,55,72),
            new Rectangle(110,0,55,72),
            new Rectangle(165,0,55,72)
        };

        int waitState = 0;

        public Rectangle[] attenteBas =
        {
            new Rectangle(0,0,55,72)
        };
        public Rectangle[] attenteHaut =
{
            new Rectangle(0,216,55,72)
        };
        public Rectangle[] attenteGauche =
{
            new Rectangle(0,72,55,72)
        };
        public Rectangle[] attenteDroite =
{
            new Rectangle(0,144,55,72)
        };




        public virtual void Update(GameTime gameTime)
        {

            if(etat == Etat.RunHaut)
            {
                spriteAffiche = tabRunHaut[runState];
            }
            if (etat == Etat.RunBas)
            {
                spriteAffiche = tabRunBas[runState];
            }
            if (etat == Etat.RunDroite)
            {
                spriteAffiche = tabRunDroite[runState];
            }
            if (etat == Etat.RunGauche)
            {
                spriteAffiche = tabRunGauche[runState];
            }
            if (etat == Etat.AttenteHaut)
            {
                spriteAffiche = attenteHaut[waitState];
            }
            if (etat == Etat.AttenteBas)
            {
                spriteAffiche = attenteBas[waitState];
            }
            if (etat == Etat.AttenteGauche)
            {
                spriteAffiche = attenteGauche[waitState];
            }
            if (etat == Etat.AttenteDroite)
            {
                spriteAffiche = attenteDroite[waitState];
            }




            //compteur permettant de generer le changement d images
            compteur++;
            if (compteur == 15)//vitesse de defoulement
            {
                runState++;
                if(runState == nbEtatsRun)
                {
                    runState = 0;
                }
                compteur = 0;
            }






        }
    }
}
