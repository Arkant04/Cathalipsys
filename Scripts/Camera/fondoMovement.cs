using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondoMovement : MonoBehaviour
{
    [SerializeField] float animatioDuration;
    [SerializeField] Vector2 velocidad;
    float seconds;
    void Start()
    {
        StartCoroutine(movimientoFondo());
    }

    public IEnumerator movimientoFondo()
    {
        while (true)
        {
            while (seconds <= animatioDuration)
            {
                seconds += Time.deltaTime;

                transform.GetComponent<SpriteRenderer>().material.mainTextureOffset += velocidad * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            seconds = 0;
            yield return null;
        }
    }
}
