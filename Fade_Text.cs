using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Fade_Text : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    float count;
    public float fadetime;
    
    void Start()
    {
        red = GetComponent<TextMeshProUGUI>().color.r;
        green = GetComponent<TextMeshProUGUI>().color.g;
        blue = GetComponent<TextMeshProUGUI>().color.b;
    }

    void Update()
    {
        count += Time.deltaTime;
        if (count > fadetime)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(red, green, blue, alfa);
            alfa += speed;
           if(count >= fadetime + 2)
            {
                enabled = false;
            }

        }
    }
}
