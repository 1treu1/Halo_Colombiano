using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public int distRadar;
    public int velRadar;
    public LayerMask mascara;
    public Transform Player;
    public Transform punteroRadar;
    public Transform camaraRadar;

    private void Update()
    {
        transform.position = Player.position;//el objeto que tenga esta script estara siguiendo al player
        transform.Rotate(0, velRadar * Time.deltaTime, 0);//Velocidad del radar que solo que aploca en el eje y de la rotación
        punteroRadar.Rotate(0, 0, -velRadar * Time.deltaTime);
        camaraRadar.position = new Vector3(Player.position.x, camaraRadar.position.y, Player.position.z);

        RaycastHit hit;//va a detectar a los enemigos
        if (Physics.Raycast(transform.position, transform.forward, out hit, distRadar, mascara))
        {
            hit.collider.GetComponentInChildren<DetectRadar>().active = true;
            Debug.Log("Detectado");
        }
    }

    private void OnDrawGizmos()//para visualizar el Raycast en escena
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distRadar);
    }
}
