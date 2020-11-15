using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] _pipes = new GameObject[8];
    [SerializeField] private GameObject _allPipes = null;

    private float _currentPipesLocX = 0;
    private float _endPipesLocX = 0;

    internal bool _canMove = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DetectedTap();
        }
    }

    private void DetectedTap()
    {
        Vector2 pos = Input.mousePosition;
        _currentPipesLocX = _allPipes.transform.position.x;

        if (pos.x > 0 && pos.x < Screen.width / 2 && _canMove) // Left
        {
            _endPipesLocX = _currentPipesLocX - 1.4f;
        }
        else if(pos.x > Screen.width / 2 && pos.x < Screen.width && _canMove) // Right
        {
            _endPipesLocX = _currentPipesLocX + 1.4f;
        }

        StartCoroutine("MoveFromTo");
    }

    private IEnumerator MoveFromTo()
    {
        if (_canMove)
        {
            _canMove = false;
            float alpha = 0;
            while (alpha < 1)
            {
                alpha += Time.deltaTime / 0.2f;
                _allPipes.transform.position = Vector3.Lerp(new Vector3(_currentPipesLocX, -5, 0), new Vector3(_endPipesLocX, -5, 0), alpha);
                yield return 0;
            }
            _canMove = true;
            RelocatingPipes();
        }
    }

    private void RelocatingPipes()
    {
        foreach (var pipe in _pipes)
        {
            if(pipe.transform.position.x < -5.0f)
            {
                pipe.transform.position = new Vector3(4.9f, pipe.transform.position.y, pipe.transform.position.z);
            }
            else if (pipe.transform.position.x > 5.0f)
            {
                pipe.transform.position = new Vector3(-4.9f, pipe.transform.position.y, pipe.transform.position.z);
            }
        }
    }
}
