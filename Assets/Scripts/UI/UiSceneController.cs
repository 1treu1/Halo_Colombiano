using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSceneController : MonoBehaviour
{
    private int Lenght;

    private void Awake()
    {
        var noDestroyBetweenEscenes = FindObjectOfType<UiSceneController>();
        if (noDestroyBetweenEscenes.Lenght > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
