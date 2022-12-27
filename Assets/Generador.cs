using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] animalesPrefabs;

    private float rangoXGenerador = 20f;
    private float posZGenerador = 20f;

    private float retardoInicial = 2.0f;
    private float intervaloGeneracion = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("GenerarAnimalAleatorio", retardoInicial, intervaloGeneracion);
    }

    // Update is called once per frame
    
void GenerarAnimalAleatorio ()
{
    int indexAnimal = Random.Range(0,animalesPrefabs.Length);
    Vector3 posGenerador = new Vector3(Random.Range(-rangoXGenerador,rangoXGenerador),0, posZGenerador);
    Instantiate(animalesPrefabs[indexAnimal], posGenerador, animalesPrefabs[indexAnimal].transform.rotation);
}
}

