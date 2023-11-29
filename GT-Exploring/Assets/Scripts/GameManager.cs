using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public enum GameState
{
    Playing,
    Pause,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;
    public AudioSource bgmSource;

    [Header("UI")]
    public TMP_Text coinText;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    [Header("UI Setting")]
    public Slider bgmSlider;

    private int _coinCount = 0;
    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.value = bgmSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                Playing();
                break;

            case GameState.Pause:
                Paused();
                break;

            case GameState.GameOver:
                GameOver();
                break;
        }
    }

    public void Playing()
    {
        gameState = GameState.Playing;
        ShowMenuPanel(false);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = GameState.Pause;
        }
    }

    public void Paused()
    {
        gameState = GameState.Pause;
        ShowMenuPanel(true);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = GameState.Playing;
        }
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        ShowGameOverPanel();
    }

    public void ShowMenuPanel(bool active)
    {
        pausePanel.SetActive(active);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ChangeVolumeBGM(float volume)
    {
        bgmSource.volume = volume;
    }

    #region Utility Gameplay
    public void AddCoin(int add)
    {
        _coinCount += add;
        coinText.text = _coinCount.ToString();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    #endregion
}
