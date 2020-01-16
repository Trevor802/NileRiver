using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeIO : MonoBehaviour
{
    public float fadingSpeed;

    bool startFading;

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
        Color color = this.GetComponent<Image>().color;
        this.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);
    }

    public void StartFadeOut()
    {

    }

    void FadeProcess()
    {

    }
}
