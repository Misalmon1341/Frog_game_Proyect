using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private bool isGameOver;
    public bool IsGameOver => isGameOver;
    public static GameOverManager Instance { get; private set; }
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        ReadGameOverValue();
    }
    public void ReadGameOverValue()
    {
           isGameOver = PlayerPrefs.GetInt(SettingsManager.PlayerPreKeys.gameOver, 0) == 1;
           Debug.Log($"Boleaan value{isGameOver}");
    }
    public void SetGameOverValue(bool value)
    {
        isGameOver = value;
        PlayerPrefs.SetInt(SettingsManager.PlayerPreKeys.gameOver, isGameOver ? 1 : 0);   
        Debug.Log("Se gardo el valor del booleano");
    }
}
