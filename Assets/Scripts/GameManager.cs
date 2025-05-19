using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int level;
    private int lives;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NewGame()
    {
        lives = 1;
        score = 0;
        LoadLevel("Level1");
    }

    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LevelComplete()
    {
        score += 1000;

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            LoadLevel("Level2"); // Go to next level
        }
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            LoadLevel(SceneManager.GetActiveScene().name); // Restart current level
        }
    }
}