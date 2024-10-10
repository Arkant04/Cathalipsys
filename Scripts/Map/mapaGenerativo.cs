using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapaGenerativo : MonoBehaviour
{
  public GameObject[] objects;
    void Start()
    {
        int randomObjeto = Random.Range(0, objects.Length);
        Instantiate(objects[randomObjeto], transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
