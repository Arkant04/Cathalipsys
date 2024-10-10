using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowCanvasOnTrigger : MonoBehaviour
{
    public GameObject canvasToShow;
    private bool isShowing = false; 

    void Start()
    {
        
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            canvasToShow.SetActive(true);
            //StartCoroutine(ShowCanvas());
        }
    }

   /* IEnumerator ShowCanvas()
    {
        isShowing = true;
        
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(true);
        }

        
        yield return new WaitForSeconds(1);

        
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(false);
        }

        isShowing = false;
    }*/
}
