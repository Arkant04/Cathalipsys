using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPlay : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Exit()
    {
        Application.Quit();

     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #endif

    }
}