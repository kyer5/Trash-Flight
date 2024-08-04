using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private int coin = 0;

    [SerializeField] 
    private TextMeshProUGUI text;

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
}
