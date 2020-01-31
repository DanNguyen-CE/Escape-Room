using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlsIMG;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.Escape)){
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
		Cursor.visible = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        AudioListener.pause = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Reset()
    {
        Resume();
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        controlsIMG.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
