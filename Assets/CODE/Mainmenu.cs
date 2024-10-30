using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button startButton;
    public Button singlePlayerButton;
    public Button multiplayerButton;
    public Button quitButton;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        singlePlayerButton.onClick.AddListener(StartSinglePlayer);
        multiplayerButton.onClick.AddListener(StartMultiplayer);
        quitButton.onClick.AddListener(QuitGame);

        singlePlayerButton.gameObject.SetActive(false);
        multiplayerButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    private void OnStartButtonClick()
    {
        singlePlayerButton.gameObject.SetActive(true);
        multiplayerButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void StartSinglePlayer()
    {
        SceneManager.LoadScene("singlePlayerScene"); // Đảm bảo tên scene chính xác
    }

    private void StartMultiplayer()
    {
        SceneManager.LoadScene("MultiplayerScene");
    }

    private void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
