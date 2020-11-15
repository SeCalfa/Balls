using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _timeToActivaition = 1.0f;

    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    private void FixedUpdate()
    {
        TimerToActivate();
    }

    private void TimerToActivate()
    {
        _timeToActivaition -= Time.fixedDeltaTime;
        if (_timeToActivaition <= 0)
            GetComponent<Collider2D>().enabled = true;
    }
}
