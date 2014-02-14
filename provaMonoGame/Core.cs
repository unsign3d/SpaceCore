
#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace provaMonoGame
{
	public class Core: DrawableGameComponent
	{
		//shows in what level we are doing stuff
		public Game game;
		
		private float angle = 0;
		
		SpriteBatch spriteBatch;

		Vector2 mPosition = new Vector2(0,0);
		Vector2 mDefaultSpeed = new Vector2(50.0f, 50.0f);
		Vector2 mSpeed = new Vector2(50.0f, 50.0f);

		Texture2D mSpriteTexture;
		
		IGraphicsDeviceService svc;
		GraphicsDeviceManager graphics;

		public Core (Game game) : base(game)
		{	
			svc = (IGraphicsDeviceService)game.Services.GetService(typeof(IGraphicsDeviceService));
			graphics =  (GraphicsDeviceManager)svc;
			//remember wich level we are playing
			this.game = game;
		}

	     protected override void LoadContent()
	     {
			
			spriteBatch = new SpriteBatch(GraphicsDevice);
			mSpriteTexture = game.Content.Load<Texture2D> ("core.png");
	     	base.LoadContent();
	     }
		
	     protected override void UnloadContent()
	     {
	
	     	base.UnloadContent();
	     }
	
	
	     public override void Update(GameTime gameTime)
	     {
			this.mPosition += this.mSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
			this.angle += 0.01f;

			//accessing keyboard 
			KeyboardState keyboardState = Keyboard.GetState();

			//accessing variables
			int maxX = graphics.GraphicsDevice.Viewport.Width - mSpriteTexture.Width;
			int minX = 0;
			int maxY = graphics.GraphicsDevice.Viewport.Height - mSpriteTexture.Height;
			int minY = 0;

			//change direction based on key press
			if (keyboardState.IsKeyDown(Keys.Right)){
				this.mSpeed.X = - this.mDefaultSpeed.X;
			}
			else if(keyboardState.IsKeyDown(Keys.Left)){
				this.mSpeed.X = this.mDefaultSpeed.X;
			}
			else if(keyboardState.IsKeyDown(Keys.Down)){
				this.mSpeed.Y = - this.mDefaultSpeed.Y;
			}
			else if(keyboardState.IsKeyDown(Keys.Up)){
				this.mSpeed.Y = this.mDefaultSpeed.Y;
			}
			

			//checking borders and adjusting positions
			if (this.mPosition.X > maxX) {
				this.mSpeed.X *= -1;
				this.mPosition.X = maxX;
			} 
			else if (this.mPosition.X < minX) {
				this.mSpeed.X *= -1;
				this.mPosition.X = minX;
			}
			else if (this.mPosition.Y > maxY) {
				this.mSpeed.Y *= -1;
				this.mPosition.Y = maxY;
			}
			else if (this.mPosition.Y < minY) {
				this.mSpeed.Y *= -1;
				this.mPosition.Y = minY;
			}
	     	base.Update(gameTime);
	     }
	
	
	     public override void Draw(GameTime gameTime)
	     {

			spriteBatch.Begin ();
			spriteBatch.Draw(mSpriteTexture,mPosition, 
				new Rectangle(0,0,mSpriteTexture.Width, mSpriteTexture.Height), 
				Color.White, angle, new Vector2(0,0), 1.0f, SpriteEffects.None, 1);
			spriteBatch.End ();

	     	base.Draw(gameTime);
	     }
	}
}

