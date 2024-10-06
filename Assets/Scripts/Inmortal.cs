using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortal : MonoBehaviour
{
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
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
}
