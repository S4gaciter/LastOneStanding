using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image img;
    bool fadeIn = false, fadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else if (fadeOut)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        Color color = img.color;
        color.a -= Time.deltaTime * 0.25f;
        img.color = color;
        if (img.color.a <= 0)
        {
            fadeIn = false;
        }
    }
    void FadeOut()
    {
        Color color = img.color;
        color.a += Time.deltaTime * 0.25f;
        img.color = color;
        if (img.color.a >= 1)
        {
            fadeOut = false;
        }
    }

    public void BeginFadeIn()
    {
        fadeIn = true;
    }
    public void BeginFadeOut()
    {
        fadeOut = true;
    }
}
