using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }
    public int gunAmmo = 20;
    public int gunMaxAmmo = 20;
    public int gunAmmo1 = 10;
    public int gunMaxAmmo1 = 10;
    public int health = 100;
    public int maxhealth = 100;
    public bool isGun = false;
    public int counterHealth;
    //public Text txtTotalEnemiesKilled;
    public int totalKills;
    public GameObject enemyContainer;

    void Start()
    {
        totalKills = enemyContainer.GetComponentsInChildren<VidaEnemigos>().Length;
        //txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
    }
    public void AddEnemyKill()
    {
        totalKills --;
        //txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
        if(totalKills <=0)
        {
            FinGame(true);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    public void AddHealth(int health)
    {
        if(this.health + health >= maxhealth)
        {
            counterHealth += 1;
            Debug.Log(counterHealth);
        }
        else
        {
            this.health += health;
        }
    }

    public void FinGame(bool isWin)
    {
        if (isWin == true)
        {
            Debug.Log("Has ganado");
        }
        else
        {
            Debug.Log("Has perdido");
        }
    }

}
