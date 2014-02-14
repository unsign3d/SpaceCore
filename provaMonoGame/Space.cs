
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
	public class Space: DrawableGameComponent
	{
		//shows in what level we are doing stuff
		public Game game;
		
		SpriteBatch spriteBatch;

		Texture2D mSpriteTexture;
		
		IGraphicsDeviceService svc;
		GraphicsDeviceManager graphics;

		public Space (Game game) : base(game)
		{	
			svc = (IGraphicsDeviceService)game.Services.GetService(typeof(IGraphicsDeviceService));
			graphics =  (GraphicsDeviceManager)svc;
			//remember wich level we are playing
			this.game = game;
		}

	     protected override void LoadContent()
	     {
			
			spriteBatch = new SpriteBatch(GraphicsDevice);
			mSpriteTexture = game.Content.Load<Texture2D> ("black.png");
	     	base.LoadContent();
	     }
		
	     protected override void UnloadContent()
	     {
	
	     	base.UnloadContent();
	     }
	
	
	     public override void Update(GameTime gameTime)
	     {
	     	base.Update(gameTime);
	     }
	
	
	     public override void Draw(GameTime gameTime)
	     {

			spriteBatch.Begin ();
			spriteBatch.Draw (mSpriteTexture,
				new Rectangle(0, 0, 
					graphics.GraphicsDevice.Viewport.Width,
					graphics.GraphicsDevice.Viewport.Height) , Color.White);
			spriteBatch.End ();

	     	base.Draw(gameTime);
	     }
	}
}

