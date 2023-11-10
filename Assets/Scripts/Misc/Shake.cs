using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;

    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.2f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;

    public bool isLocal;

    private void Awake()
    {
        if (isLocal)
        {
            _startPos = transform.localPosition;
        }
        else
        {
            _startPos = transform.position;
        }
    }

    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Untagged")
        {
            StopAllCoroutines();
            StartCoroutine(TShake());
        }
    }


    private IEnumerator TShake()
    {
        _timer = 0f;

        while (_timer < _time)
        {
            _timer += Time.deltaTime;

            _randomPos = _startPos + (Random.insideUnitSphere * _distance);

            if (isLocal)
            {
                transform.localPosition = _randomPos;
            }
            else
            {
                transform.position = _randomPos;
            }

            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
        if (isLocal)
        {
            transform.localPosition = _startPos;
        }
        else
        {
            transform.position = _startPos;
        }
    }
}
