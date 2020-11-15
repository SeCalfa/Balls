using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _bestScore = null;
    [SerializeField] private DataStorage _dataStorage = null;

    private void Awake()
    {
        _bestScore.text = _dataStorage.BestScoreGet().ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
