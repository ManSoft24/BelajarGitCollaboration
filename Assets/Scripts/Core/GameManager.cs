using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentState = GameState.Playing;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                PauseGame();
            }
            else if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game");
        Time.timeScale = 1f;
        currentState = GameState.Playing;
    }

    public void PauseGame()
    {
        Debug.Log("Pausing Game");
        Time.timeScale = 0f;
        currentState = GameState.Paused;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}