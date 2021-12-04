using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseButtons : MonoBehaviourPunCallbacks
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("GameLobby");
        PhotonNetwork.LeaveRoom();
        
    }

    public void QuitGame()
    {
        Application.Quit();
        PhotonNetwork.LeaveRoom();
    }
}
