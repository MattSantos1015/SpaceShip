using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = this.transform.GetChild(0).gameObject; 
        pauseMenu.SetActive(false); //make sure to turn off pasue menu at start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        
        { 
        PauseGame();
        }
    }
     public void PauseGame()
    {
      if (!gameIsPaused) 
        { 
       // game is not paused lets pause it
            gameIsPaused = true;
            pauseMenu.SetActive(true);
            // set time scale to zero // pause everyting when the game is paused
            Time.timeScale = 0;
        
        }
      else
        {
            gameIsPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1; // upauses everything when the game is resumed

        }

    }
}
