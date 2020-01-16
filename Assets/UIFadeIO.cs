using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeIO : MonoBehaviour
{
    bool startFading;
    float fadingSpeed;
    
    private void Start()
    {
        Color color = this.GetComponent<Image>().color;
        color = new Color(color.r, color.g, color.b, 0f);
    }

    private void Update()
    {
        
    }

    public void StartFadeIn()
    {
        this.GetComponent<Image>().CrossFadeAlpha(0.1f, 2f, false);
    }

    public void StartFadeOut()
    {

    }

    void FadeProcess()
    {

    }
}
