# Simple tutorial series about the basics of Monogame.

## What is Monogame?
Monogame is one of the successors to the XNA game studios library from Microsoft.
https://www.monogame.net/

Monogame is a library or framework that lets you use C# to create applications and games.  It creates a high level set of functions/procedures, classes, and frameworks so that you can focus more on your game, and less on the implementations.

There is an abstraction layer, where you create your code, and then Monogame will be the one doing the hard work for each platform.

# Tutorials

Going forward I'll leave the BRANCH for each tutorial in place instead of deleting them.  Branches for Tutorials 1, 2, and git are missing.

## 1) Tutorial 1: Installing Monogame, Visual Studio, and making your first project
https://www.youtube.com/watch?v=Pu_Hi3ThVPs

 * Installing Visual Studio 2022
 * Installing MonoGame Extension
 * Create a new MonoGame Project
 * Running your project
 * High Level Blank Project Overview


## 2) Tutorial 2: Load, draw, and move an image.  Compile and run your program.
https://www.youtube.com/watch?v=F5V7-7Z1d1I

* Obtain an image
* Create a simple image in MSPaint
* Add Image to Content Pipeline
* Load Image into Variable
* Draw Image on Screen
* Move an Image (Basic)
* Move an Image (Better)
* Move an Image (Best)
* Move an Image (keyboard)
* Restrict to Screen
* Center Draw Position

## OC1) Tutorial (Off-course 1): General coding - high level GIT info
https://www.youtube.com/watch?v=_n_hoj0YLYE

Quick video about Source Control Systems like GIT.

* What is git
* example of why to use VCS
* Create a repository
* Create a branch
* Add a file for tracking
* Commit the changes
* Make changes and commit again
* Push and Clone

__General workflow of using git:__
 1. git clone yourrepo.git
    1. If you already have the repository cloned, you need to download the changes with: git pull
    1. NOTE: Make sure you are ON the main branch, or branch you want to update when doing this
 1. git checkout -b "your-new-branch-name"
 1. make your changes to files
 1. git add filename.cs
    1. alternative to all ALL changes, git add . 
 1. git commit -m "i changed the file"
 1. git push


## 3) Tutorial 3: Loading fonts and Drawing text
https://www.youtube.com/watch?v=q2OESdgeoOI


### 3.A) Creating a font file

 1. Open your project
 1. Double-click on Content.mgcb to Open MGCB
 1. Right-click on the Content tree root item select Add Item
 1. Select SprintFont Description (.spritefont)
 1. A generic file will be created with Arial font style
 1. Save and BUILD the content to make sure it works
 1. Close MGCB
 1. Open the spritefont file in visual studio or a text editor.
 1. Edit the FoneName, Size, Spacing, etc.

### 3.B) Loading the font
	private SpriteFont font;
	font = Content.Load<SpriteFont>("gameFont");

### 3.C) Drawing text with the font
	Vector2 fontDrawPos = new Vector2(50, 50);
	_spriteBatch.Begin();
	_spriteBatch.DrawString(font, "Hi", fontDrawPos, Color.Blue);
	_spriteBatch.End();

### 3.D) Advanced topics:
 1. Localization and RESX files
	https://docs.monogame.net/articles/content/localization.html
	
 2. Creating your own font
	There are tools that let you create your own font.  
	You could theoretically use this created font in your game.
	
 3. Build your own.
	Realistically, you could generate your own code to load
	an image in, with a NxN grid of letters that map to the
	ASCII character codes if you want more control over your 
	font drawing.
	
	However, this is overkill for 95% of games.

### 3.E) Links:
https://docs.monogame.net/articles/content/using_mgcb_editor.html#fontsaddingttffontsmd

## 4) Tutorial 4: Loading and Playing Sounds/Music

### 4.A) Sounds and Music (Intro)
Adding sound to a game adds an entire new feeling to the game.  A simple unfinished game will "Feel" 100 times better if it has sound and music.

There is and entire industry, department, and field about sound and audio theory.  I will not be approaching this from any of those areas.  This will be basic.

Eventually you'll want to look into sound theory, positioning of sounds, merging sounds together when too many sounds are happening at the same time, and so much more.

### 4.B) Generating sounds/Music for free (not AI):
__SOUNDS:__
 * https://sfxr.me/
 * https://www.leshylabs.com/apps/sfMaker/
 * https://sfbgames.itch.io/chiptone
 
__MUSIC:__
 * https://www.beepbox.co/

### 4.C) Adding sounds to your game (Basic)

 1. Add sound file to your content directory
    1. Add a folder under your content folder called "sounds"
	1. Right-click the folder and those add existing item.  
	1. Search for and find your sound file.
 1. Add to MGCB (Content Pipeline)
    1. Open MGCB, right-click content and chose add -> existing file
	1. Select your sound.
	1. Save and BUILD the MGCB to validate no errors.
 1. Load content in your game
    1. Add a variable to store the sound file.
	
			private SoundEffect laserEffect;
		
	1. Add a variable to store the master volume for sound effects.
	
			private float soundEffectVolumne = 0.25f;
	
	1. Load the sound file content via the content pipeline
	
			laserEffect = Content.Load<SoundEffect>(@"sounds\laserShoot");
	
 1. Play Sound Effect
 	1. Add code to play the sound when the space bar is pressed

			if (kstate.IsKeyDown(Keys.Space))
			{
				// Play the sound, at 25% volume, no pitch change, center balanced in the headphones/speaker
				laserEffect.Play(soundEffectVolumne, 0.0f, 0.0f);
			}

### 4.D) Adding sounds to your game (Intermediate)
This builds off the Basic steps above in 4.C) so go back and do those if you haven't yet.

 1. Setup content in your game
    1. Add a variable to store the instance (You could also create this on-the-fly)
	
			private SoundEffectInstance laserEffectInstance;
	
	1. Create the instance from the loaded sound effect.
	
		laserEffectInstance = laserEffect.CreateInstance();
	
 1. Play Sound Effect (Using Sound Effect Instance).
 
		    if (kstate.IsKeyDown(Keys.I))
            {
                if (laserEffectInstance.State != SoundState.Playing)
                {
                    laserEffectInstance.Volume = soundEffectVolumne;
                    laserEffectInstance.Play();
                }
            }
			
	   * This gives more control over the sound, things like:
          * the virtual position in space it is played at (sound like its coming from above, below, behind, in front, left, or right)
		  * when it's playing (checking state, pausing, stopping)
       * See the links section for details on the SoundEffect class

### 4.E) Adding music to your game (basic)

We will use the basic MediaPlayer library/class to play music.

 1. Add music file to your content directory
    1. Add a folder under your content folder called "music"
	1. Right-click the folder and those add existing item.  
	1. Search for and find your song/music file.
 1. Add to MGCB (Content Pipeline)
    1. Open MGCB, right-click content and chose add -> existing file
	1. Select your song/music.
	1. Save and BUILD the MGCB to validate no errors.
 1. Load content in your game
    1. Add a variable to store the music file.
	
			private Song song;
	
	1. Load the song/music file content via the content pipeline
	
			song = Content.Load<Song>(@"music\simpleSong");
	
 1. Play Song
 	1. Add code to play the sound when the space bar is pressed

            if (kstate.IsKeyDown(Keys.M))
            {
                if (MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Stop();
                }
                else { 
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Volume = soundEffectVolumne;
                    MediaPlayer.Play(song);
               }
            }

### 4.F) Links:
 * https://docs.monogame.net/articles/content/using_mgcb_editor.html#audio
 * https://docs.monogame.net/api/Microsoft.Xna.Framework.Audio.SoundEffect.html
 * https://docs.monogame.net/api/Microsoft.Xna.Framework.Audio.SoundEffectInstance.html
 * https://docs.monogame.net/api/Microsoft.Xna.Framework.Media.Song.html
 * https://docs.monogame.net/api/Microsoft.Xna.Framework.Media.MediaPlayer.html

### 4.G) Errors and Resolutions
__Microsoft.Xna.Framework.Audio.NoAudioHardwareException__

	Error Message: Microsoft.Xna.Framework.Audio.NoAudioHardwareException: 'OpenAL device could not be initialized, see console output for details.'
	Error Details: I ran into this odd error when I was recording because I accidentally had the sound off on the remote computer.
	Error Resolution: Make sure your computer has an audio device, and that isn't not disabled.