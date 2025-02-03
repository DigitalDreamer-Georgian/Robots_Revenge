using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPaused = false;

    void Start()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void OnGameResumePress()
    {
        ResumeGame();
    }

    public void OnGameExitPress()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        isPaused = true;
    }

    private void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
    }
}
