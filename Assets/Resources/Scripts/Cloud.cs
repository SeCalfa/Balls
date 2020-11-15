using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField][Range(0, 100)] private float _speed = 0;
    private float _minXloc = -4.2f;

    private void FixedUpdate()
    {
        CloudMove();
    }

    private void CloudMove()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - Time.fixedDeltaTime * _speed / 100, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.x <= _minXloc)
            transform.localPosition = new Vector3(Mathf.Abs(_minXloc), transform.localPosition.y, transform.localPosition.z);
    }
}
