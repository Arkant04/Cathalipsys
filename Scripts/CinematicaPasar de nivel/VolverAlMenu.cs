using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    [SerializeField] float seconds;
    void Start()
    {
        FinalDeLaCinematica(seconds);
    }

    public void FinalDeLaCinematica(float seconds)
    {
        StartCoroutine(AcabarCinematica(seconds));
    }


    private IEnumerator AcabarCinematica(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
    }
}
