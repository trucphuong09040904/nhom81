using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,

    }
    GameManagerState GMState;
     void Start()
    {
        GMState = GameManagerState.Opening;
    }
     void UpdateGamemanagerState ()
    {
        switch(GMState) {
            case GameManagerState.Opening:
                break; 
         case GameManagerState.Gameplay:
                playButton .SetActive(false);
                playerShip.GetComponent<Playercontrol>().Init();
                break;


            case GameManagerState.GameOver:
                playButton.SetActive(true);  // Hiển thị lại nút Play khi game over
                break;
                
        }

    }    
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGamemanagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGamemanagerState();
    }
}



   
