using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_Image : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    public float count;
    public float fadetime;
    public bool check_I;
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }
    void Update()
    {
        count += Time.deltaTime;
        if (count > fadetime)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
            if (alfa >= fadetime + 4 && alfa <= fadetime + 6)
            {
                Debug.Log("Fade_Image");
                check_I = true;

            }
        }
    }
}
