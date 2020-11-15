using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private enum PipeType
    {
        Blue,
        Green,
        Red,
        Yellow
    }

    // 0 - Main, 1 - Bot, 2 - Top
    [SerializeField] private Sprite[] _bluePipe = new Sprite[3];
    [SerializeField] private Sprite[] _greenPipe = new Sprite[3];
    [SerializeField] private Sprite[] _redPipe = new Sprite[3];
    [SerializeField] private Sprite[] _yellowPipe = new Sprite[3];

    [SerializeField] private PipeType _pipe = PipeType.Blue;

    [Header("Pipe elements")]
    [SerializeField] private SpriteRenderer[] _main = new SpriteRenderer[3];
    [SerializeField] private SpriteRenderer _bot = null;
    [SerializeField] private SpriteRenderer _top = null;

    private void Awake()
    {
        InitalSetup();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_pipe.ToString() == collision.tag)
        {
            Spawner.spawner.gameUI().AddScore();
            Destroy(collision.gameObject);
        }
        else
        {
            Spawner.spawner.GetComponent<Controller>()._canMove = false;
            Spawner.spawner.gameUI().GameOver();
            Spawner.spawner.LoseGame();
        }
    }

    private void InitalSetup()
    {
        Sprite mainIS = null;
        Sprite botIS = null;
        Sprite topIS = null;

        switch (_pipe)
        {
            case PipeType.Blue:
                mainIS = _bluePipe[0];
                botIS = _bluePipe[1];
                topIS = _bluePipe[2];
                break;
            case PipeType.Green:
                mainIS = _greenPipe[0];
                botIS = _greenPipe[1];
                topIS = _greenPipe[2];
                break;
            case PipeType.Red:
                mainIS = _redPipe[0];
                botIS = _redPipe[1];
                topIS = _redPipe[2];
                break;
            case PipeType.Yellow:
                mainIS = _yellowPipe[0];
                botIS = _yellowPipe[1];
                topIS = _yellowPipe[2];
                break;
        }

        foreach (var main in _main)
        {
            main.sprite = mainIS;
        }
        _bot.sprite = botIS;
        _top.sprite = topIS;
    }

}
