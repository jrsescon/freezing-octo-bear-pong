using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace myPong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Racket p1;
        Racket p2;
        Rectangle botBar, topBar;
        Texture2D plain;
        KeyboardState oldKeyboardState, currentKeyboardState;
        Ball b;
        int upLim;
        int botLim;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            upLim = 20;
            botLim = 400;
            p2 = new Racket(50, 50, 2, upLim, botLim);
            p1 = new Racket(730, 50, 2, upLim, botLim);
            b = new Ball(400, 250);
            botBar = new Rectangle(0, botLim+10, 800, 5);
            topBar = new Rectangle(0, upLim-5, 800, 5);
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
            plain = new Texture2D(GraphicsDevice, 1, 1);
            plain.SetData(new Color[] { Color.White });

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                p1.moveUp();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                p1.moveDown();
            }
            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                p2.moveUp();
            }
            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                p2.moveDown();
            }
            
            
            if (p2.getRectangle().Intersects(b.getRectangle()))
            {
               // b.reflectY();
                b.relfectX();
                b.vY = b.vY * 2;
                b.vX = b.vX * 2;
                p1.speed = p1.speed * 2;
                p2.speed = p2.speed * 2;
            }
            if (p1.getRectangle().Intersects(b.getRectangle()))
            {
              //  b.reflectY();
                b.relfectX();
                b.vY = b.vY * 2;
                b.vX = b.vX * 2;
                p1.speed = p1.speed * 2;
                p2.speed = p2.speed * 2;
            }

            if (b.curX < 0 || b.curX > 800)
            {
                b.reset();
            }
            

            //Rectangle temp3 = p1.getRectangle();
            //Rectangle temp = new Rectangle(temp3.X, temp3.Y, temp3.Width, (int)(temp3.Height / 2));
            //Rectangle temp2 = new Rectangle(temp3.X, temp3.Y + (int)(temp3.Height / 2), temp3.Width, (int)(temp3.Height / 2));
            //if (b.getRectangle().Intersects(temp) && b.getRectangle().Intersects(temp2))
            //{
            //    b.vY = 0;
            //}
            //else if (b.getRectangle().Intersects(temp))
            //{
            //    if (b.vY > 0)
            //    {
            //        b.vY = (int)(b.vY / 2);
            //    }
            //    else if (b.vY < 0)
            //    {

            //    }
            //    else if (b.vY == 0)
            //    {

            //    }
            //    b.relfectX();
            //}
            //else if (b.getRectangle().Intersects(temp2))
            //{

            //}

            if (b.curY < upLim)
            {
                b.reflectY();
            }
            if (b.curY > botLim)
            {
                b.reflectY();
            }
            b.update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // TODO: Add your drawing code here
            spriteBatch.Draw(plain, p1.getRectangle(), Color.White);
            spriteBatch.Draw(plain, p2.getRectangle(), Color.White);
            spriteBatch.Draw(plain, b.getRectangle(), Color.White);
            spriteBatch.Draw(plain, topBar, Color.White);
            spriteBatch.Draw(plain, botBar, Color.White);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
