using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }
    public int gunAmmo = 10;
    public int health = 100;
    public int maxhealth = 100;

    private void Awake()
    {
        Instance = this;
    }
    public void AddHealth(int health)
    {
        if(this.health + health >= maxhealth)
        {
            this.health = 100;
        }
        else
        {
            this.health += health;
        }
    }
}
