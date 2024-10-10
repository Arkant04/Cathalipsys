using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPlay : MonoBehaviour
{
    [SerializeField] GameObject menuInicial;
    [SerializeField] GameObject menuCreadores;
    [SerializeField] GameObject menuPoderes;

    private void Start()
    {
        menuCreadores.SetActive(false);
        menuInicial.SetActive(true);
        menuPoderes.SetActive(false);
    }
    public void Jugar()
    {
        Debug.Log("Botón play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("Pruebas");
    }


    public void Creditos()
    {
        menuCreadores.SetActive(true);
        menuInicial.SetActive(false);
        menuPoderes.SetActive(false);
    }

    public void Poderes()
    {
        menuCreadores.SetActive(false);
        menuInicial.SetActive(false);
        menuPoderes.SetActive(true);
    }

    public void Volver()
    {
        menuCreadores.SetActive(false);
        menuInicial.SetActive(true);
        menuPoderes.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}