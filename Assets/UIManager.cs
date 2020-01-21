using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        //Debug.Log("Load game scene");
        SceneManager.LoadScene("Game");
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
}
