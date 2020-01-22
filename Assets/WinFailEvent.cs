using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinFailEvent : MonoBehaviour
{
    public int enemyCount = 1;
    public UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilledEvt()
    {
        enemyCount--;
        if (enemyCount <= 0 && !GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().isDead)
        {
            PlayerWins();
        }
    }

    void PlayerWins()
    {
        GetComponent<UIManager>().WinScreen();
    }

    public void GameOverScreen()
    {
        GetComponent<UIManager>().GameOver();
    }

}
