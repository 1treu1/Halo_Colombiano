using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animationEnemy;
    public delegate void FollowAction();
    public static event FollowAction OnFollow;
    public delegate void NoFollowAction();
    public static event NoFollowAction OnNoFollow;
    public NavMeshAgent enemy;
    public Transform[] nodo;
    private int index = 0;
    public EnemyShoot enemyShoot;
    public bool followPlayer;
    private GameObject player;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;
    public float distanceToFollowPath = 2;
    bool walkEnemy;
    void Start()
    {

        if (nodo == null  || nodo.Length == 0)
        {
            transform.gameObject.GetComponent<IA>().enabled = false;
        }
        else
        {
            enemy.destination = nodo[0].position;
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            OnFollow();
            FollowPlayer();
            walkEnemy = true;
            animationEnemy.SetBool("Run", walkEnemy);
        }
        else
        {
            walkEnemy = false;
            animationEnemy.SetBool("Run", walkEnemy);
            EnemyPath();
            
        }
    }

    public void EnemyPath()
    {
        
        enemy.destination = nodo[index].position;
        if(Vector3.Distance(transform.position, nodo[index].position) <= distanceToFollowPath)
        {
            if(nodo[index] != nodo[nodo.Length - 1])
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
    public void FollowPlayer()
    {
        enemy.destination = player.transform.position;
    }
    public void GrenadeImpact()
    {
        Destroy(gameObject);
    }
}
