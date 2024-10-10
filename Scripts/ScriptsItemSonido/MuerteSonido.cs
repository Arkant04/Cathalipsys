using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteSonido : MonoBehaviour
{
    [SerializeField] private AudioClip collect1;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            ControladorDeSonido.Instance.EjecutarSonido(collect1);
        }
    }
}
