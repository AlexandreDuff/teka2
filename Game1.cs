using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Teka
{

    // ----------------------------------------------------------------------------------INTRO------------------------------------------------------------------------------------------------
    // Alexandre Dufresne et Samuel Joyal
    // Projet MonoGame
    // TEKA
    // "The enchanted kingdom of Astria"
    //-----------------------------------------------------------------------------------INTRO------------------------------------------------------------------------------------------------

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keys = new KeyboardState();
        KeyboardState previousKeys = new KeyboardState();
        Rectangle fenetre;
        GameObjectAnime persoPrincipal;
        bool intro = true;
        GameObject mapIntro;
        bool battle = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;  
            graphics.PreferredBackBufferHeight = 1000;   
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            persoPrincipal = new GameObjectAnime();
            persoPrincipal.estVivant = true;  //seulement pour l instant
            persoPrincipal.vitesse = 0;   //c est la map qui bouge
            persoPrincipal.sprite = Content.Load<Texture2D>("SpriteSheet.png"); // ajouter image de base
            persoPrincipal.position = new Rectangle(0, 0, 50, 72);
            persoPrincipal.direction = Vector2.Zero;
            persoPrincipal.etat = GameObjectAnime.Etat.AttenteBas;
            persoPrincipal.position.Offset(fenetre.Center.X + persoPrincipal.sprite.Width/2, fenetre.Center.Y + persoPrincipal.sprite.Height/2);  // sa a l air assez loin
            mapIntro = new GameObject();
            mapIntro.estVivant = true;
            mapIntro.vitesse = 10;
            mapIntro.sprite = Content.Load<Texture2D>("MapIntro.png");
            mapIntro.position = mapIntro.sprite.Bounds;
            mapIntro.position.Offset(mapIntro.sprite.Width/-4, mapIntro.sprite.Height/-4);
            
            

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------Start update

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                mapIntro.position.Y += mapIntro.vitesse;
                persoPrincipal.etat = GameObjectAnime.Etat.RunHaut;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                mapIntro.position.Y -= mapIntro.vitesse;
                persoPrincipal.etat = GameObjectAnime.Etat.RunBas;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                mapIntro.position.X += mapIntro.vitesse;
                persoPrincipal.etat = GameObjectAnime.Etat.RunGauche;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.W))
            {
                mapIntro.position.X -= mapIntro.vitesse;
                persoPrincipal.etat = GameObjectAnime.Etat.RunDroite;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                if(persoPrincipal.etat == GameObjectAnime.Etat.RunHaut)
                {
                    persoPrincipal.etat = GameObjectAnime.Etat.AttenteHaut;
                }
                if (persoPrincipal.etat == GameObjectAnime.Etat.RunBas)
                {
                    persoPrincipal.etat = GameObjectAnime.Etat.AttenteBas;
                }
                if (persoPrincipal.etat == GameObjectAnime.Etat.RunGauche)
                {
                    persoPrincipal.etat = GameObjectAnime.Etat.AttenteGauche;
                }
                if (persoPrincipal.etat == GameObjectAnime.Etat.RunDroite)
                {
                    persoPrincipal.etat = GameObjectAnime.Etat.AttenteDroite;
                }
            }


            persoPrincipal.Update(gameTime);
            base.Update(gameTime);
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------End update
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------Start Fonctions


        protected void Battle()
        {
            battle = true;



        }




        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------End fonctions


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if(intro == true)
            {
                spriteBatch.Draw(mapIntro.sprite, mapIntro.position, Color.White);
            }

            if(battle == true)
            {


            }
            spriteBatch.Draw(persoPrincipal.sprite, persoPrincipal.position,persoPrincipal.spriteAffiche, Color.White);






            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
