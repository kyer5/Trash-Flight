using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;

    [SerializeField] 
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin++;
        text.SetText(coin.ToString());

        if (coin % 30 == 0) // 30, 60, 90, ...
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
        
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
