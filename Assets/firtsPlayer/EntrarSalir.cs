using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarSalir : MonoBehaviour
{
    [Header("Componentes del Player1:")]
    public Behaviour _scriptControlador;
    public GameObject _canvas;

    [Header("Variables de Interaccion:")]
    public float distanciaDeInteraccion = 2F;
    public bool dentroDelPlayer = false;

    CharacterController _controller;
    GameObject player;

    bool enRango;
    float distancia;
    GameObject target;
    public GameObject CarEngine;
    public GameObject CarCamera;
    public PrometeoCarController CarController;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Car");
        target = GameObject.Find("Target");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if(distancia <= distanciaDeInteraccion)
        {
            enRango = true;
        }
        else
        {
            enRango = false;
        }

        if(enRango && !dentroDelPlayer)
        {
            _canvas.SetActive(true);
        }
        if(!enRango || dentroDelPlayer)
        {
            _canvas.SetActive(false);
        }

        if(dentroDelPlayer)
        {
            _scriptControlador.enabled = false;
            _controller.enabled = false;
            CarEngine.SetActive(true);
            CarCamera.SetActive(true);
            CarController.enabled=true;
            

            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;

            gameObject.transform.SetParent(target.transform);
        }
        else
        {
            gameObject.transform.SetParent(null);
            
            _scriptControlador.enabled = true;
            _controller.enabled = true;
            CarEngine.SetActive(false);
            CarCamera.SetActive(false);
            CarController.enabled=false;

        }
         
        if(enRango && !dentroDelPlayer && Input.GetKeyUp(KeyCode.E))
        {
            dentroDelPlayer = true;
        }
        
        else if(dentroDelPlayer && Input.GetKeyUp(KeyCode.E))
        {
            dentroDelPlayer = false;
        }
    }
}
