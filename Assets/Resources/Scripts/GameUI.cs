using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText = null;
    [SerializeField] private Text _scoreGameOver = null;
    [SerializeField] private GameObject _gameOverPanel = null;
    [SerializeField] private GameObject _scorePanel = null;
    [SerializeField] private GameObject _leftButton = null;
    [SerializeField] private GameObject _rightButton = null;

    internal int _score = 0;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
    }

    internal void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    internal void GameOver()
    {
        _leftButton.SetActive(false);
        _rightButton.SetActive(false);
        _scorePanel.SetActive(false);
        _scoreGameOver.text = _score.ToString();
        _gameOverPanel.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
