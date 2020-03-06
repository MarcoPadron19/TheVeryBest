using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // "static" means that there can only be one of these in the scene. So if anything
    // calls for gm, it will access the GameManager. And that's fine, because you only
    // want one of those.
    public static GameManager gameManagerInstance = null;
    [Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
    public GameObject player;

    public enum gameStates { Playing, Death, GameOver, BeatLevel };
    public gameStates gameState = gameStates.Playing;

    public static int score = 0;
    public static int reviveStar;

    public GameObject mainCanvas;
    public Text heliumPickedUp;
    public Text starHasThisMuch;
    public GameObject gameOverCanvas;
    public Text gameOverScoreDisplay;

    public GameObject canvas;

    public AudioSource backgroundMusic;
    public AudioClip gameOverSFX;

    private Health playerHealth;

    private Transform playerStart;



    void Start()
    {
        //reviveStar = StarAbsorb.starsNeededToRevive;
        // If there is no instance of the game manager, this is that instance
        // if there already is one, and it isn't this, kill it. (this is 
        // standard boilerplate game manager stuff. You should always have a
        // bit like this to make sure you don't end up with multiples
        if (gameManagerInstance == null)
            gameManagerInstance = gameObject.GetComponent<GameManager>();
        else if (gameManagerInstance != this)
            Destroy(gameObject);

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // This sets the player. I've also tagged the Player as "Player". You 
        // can see this in the Inspector. Tags are useful for finding things.
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }


        mainCanvas = GameObject.FindGameObjectWithTag("Main_Menu_canvas");

        // make other UI inactive
        //        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("canvas-for_game");
            heliumPickedUp = GameObject.FindGameObjectWithTag("H_PickedUp").GetComponent<Text>();
            starHasThisMuch = GameObject.FindGameObjectWithTag("S_PickedUp").GetComponent<Text>();
            // setup score display
            heliumPickedUp.text = score.ToString();
            starHasThisMuch.text = reviveStar.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main Menu"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Main_Menu_canvas");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            score = 0;
            if(reviveStar >= 10)
            {
                reviveStar = 0;
                starHasThisMuch.text = reviveStar.ToString();
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Death"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Death_Canvas");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            score = 0;
            if (reviveStar >= 10)
            {
                reviveStar = 0;
                starHasThisMuch.text = reviveStar.ToString();
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Win"))
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Win_canvas");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            score = 0;
            if (reviveStar >= 10)
            {
                reviveStar = 0;
                starHasThisMuch.text = reviveStar.ToString();
            }
        }
        /*     switch (gameState)
             {
                 case gameStates.Playing:
                     if (playerHealth.isAlive == false)
                     {
                         // update gameState
                         gameState = gameStates.Death;

                         // set the end game score
                         gameOverScoreDisplay.text = mainScoreDisplay.text;

                         // switch which GUI is showing      
                         mainCanvas.SetActive(false);
                         gameOverCanvas.SetActive(true);
                     }
                     else if (score >= beatLevelScore)
                     {
                         // update gameState
                         gameState = gameStates.BeatLevel;

                         // hide the player so game doesn't continue playing
                         player.SetActive(false);

                         // switch which GUI is showing          
                         mainCanvas.SetActive(false);
                         beatLevelCanvas.SetActive(true);
                     }

                     break;
                 case gameStates.Death:
                     backgroundMusic.volume -= 0.01f;
                     if (backgroundMusic.volume <= 0.0f)
                     {
                         AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);

                         gameState = gameStates.GameOver;
                     }
                     break;
                 case gameStates.BeatLevel:
                     backgroundMusic.volume -= 0.01f;
                     if (backgroundMusic.volume <= 0.0f)
                     {
       //                  AudioSource.PlayClipAtPoint(beatLevelSFX, gameObject.transform.position);

                         gameState = gameStates.GameOver;
                     }
                     break;
                 case gameStates.GameOver:
                     // nothing
                     break;
             }
             */ //We don't have different game states just yet...
    }

    // This method is called by the pickup to increase the score, then update the score on the screen
    public void IncreaseScore(int increaseInScore)
    {
        score += increaseInScore;
        heliumPickedUp.text = score.ToString();
    }

    public void StarRevive(int revivingStar)
    {
        if(reviveStar >= 10)
        {
            reviveStar = 0;
            starHasThisMuch.text = reviveStar.ToString();
        }
        reviveStar += score;
        starHasThisMuch.text = reviveStar.ToString();
        score = score - revivingStar;
        heliumPickedUp.text = score.ToString();
    }
}