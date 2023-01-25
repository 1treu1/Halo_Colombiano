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
    public RotationTorret Torreta;
    public PlayerContr Torreta1;
    public PlayerContr Torreta2;
    public MouseCamera Elevacion;
    public MouseCamera Elevacion2;
    public GameObject CarEngine;
    public GameObject CarCamera;
    public PrometeoCarController CarController;
    public GameObject CarEffects;
    public GameObject CarMira;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            Torreta.enabled=true;
            Torreta1.enabled=true;
            Torreta2.enabled=true;
            Elevacion.enabled=true;
            Elevacion2.enabled=true;
            CarEngine.SetActive(true);
            CarCamera.SetActive(true);
            CarController.enabled=true;
            CarEffects.SetActive(true);
            CarMira.SetActive(true);
            

            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;

            gameObject.transform.SetParent(target.transform);
        }
        else
        {
            gameObject.transform.SetParent(null);
            
            _scriptControlador.enabled = true;
            _controller.enabled = true;
            Torreta.enabled=false;
            Torreta1.enabled=false;
            Torreta2.enabled=false;
            Elevacion.enabled=false;
            Elevacion2.enabled=false;
            CarEngine.SetActive(false);
            CarCamera.SetActive(false);
            CarController.enabled=false;
            CarEffects.SetActive(false);
            CarMira.SetActive(false);

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
