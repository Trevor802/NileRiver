using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winningScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    GameOver();
        //}
    }

    public void GameOver()
    {
        //Debug.Log("Game overing...");
        gameOverScreen.SetActive(true);
        if(gameOverScreen)
        {
            gameOverScreen.GetComponent<Animator>().SetBool("GameOver", true);
        }
    }

    public void WinScreen()
    {
        winningScreen.SetActive(true);
    }

    public void GameOverRestart()
    {
        StartCoroutine("RestartGame");
    }

    public void GameStart()
    {
        //Debug.Log("Load game scene");
        SceneManager.LoadScene("NewGame");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayerWin()
    {

    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("NewGame");
    }
}
