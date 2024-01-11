using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startingBalance = 150;
    [SerializeField] private int _currentBalance;
    [SerializeField] private TextMeshProUGUI _goldBalanceText;
    public int CurrentBalance { get { return _currentBalance; } }

    private void Awake()
    {
        _currentBalance = _startingBalance;
        UpdateGoldText();
    }

    public void Deposit(int amount)
    {
        _currentBalance += Mathf.Abs(amount);
        UpdateGoldText();
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= Mathf.Abs(amount);
        UpdateGoldText();

        if (_currentBalance < 0)
        {
            ReloadLevel();
        }
    }

    private void UpdateGoldText()
    {
        _goldBalanceText.text = $"Gold: <color=white>{_currentBalance}</color>";
    }

    private void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}