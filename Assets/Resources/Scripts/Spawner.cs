using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;

    [SerializeField] private Transform[] _spawnPoints = new Transform[4];
    [SerializeField] private GameObject[] _animals = new GameObject[4];
    [SerializeField] private GameUI _gameUI = null;
    [SerializeField] private Text _bestScore = null;

    private int randPoint = -1;

    private void Start()
    {
        spawner = this;
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        int newPoint = Random.Range(0, 4);
        while(newPoint == randPoint)
        {
            newPoint = Random.Range(0, 4);
        }

        randPoint = newPoint;
        int randAnimal = Random.Range(0, 4);

        Instantiate(_animals[randAnimal], _spawnPoints[randPoint].position, Quaternion.identity)
            .GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);

        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        StartCoroutine("Spawn");
    }

    public GameUI gameUI()
    {
        return _gameUI;
    }

    internal void LoseGame()
    {
        StopCoroutine("Spawn");
        _bestScore.text = GetComponent<DataStorage>().ScoreCheck(_gameUI._score).ToString();
    }
}
