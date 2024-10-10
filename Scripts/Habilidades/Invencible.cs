using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invencible : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    [SerializeField] GameObject[] invencibleHB;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }


    public void DesactivarColliderTemporalmente(float tiempo)
    {
        StartCoroutine(DesactivarActivarCollider(tiempo));
    }


    IEnumerator DesactivarActivarCollider(float tiempo)
    {

        boxCollider.enabled = false;

        yield return new WaitForSeconds(tiempo);

        boxCollider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("invencible"))
        {
            StartCoroutine(DesactivarActivarCollider(7.0f));
            invencibleHB[0].SetActive(false);
        }


        if (collision.gameObject.CompareTag("invencible1"))
        {
            StartCoroutine(DesactivarActivarCollider(7.0f));
            invencibleHB[1].SetActive(false);
        }
    }
}
