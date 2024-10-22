using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeOut_Text : MonoBehaviour
{


    public GameObject Textfade;   //フェードテキストの取得

    TextMeshProUGUI FadeColor;  //フェードテキストの取得変数
    
    private float alpha ,red, green, blue;  //RGBA取得変数

    private bool fadeout;          //フェードアウトのフラグ変数

    public float m_FadeOutActionTimer;            //シーンの移動先ナンバー取得変数


    // Use this for initialization
    void Start()
    {

        FadeColor = GetComponent<TextMeshProUGUI>(); //テキストを取得
        
        alpha = FadeColor.color.a;                 //パネルのalpha値を取得
        red = FadeColor.color.r;
        green = FadeColor.color.g;
        blue = FadeColor.color.b;
        fadeout = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_FadeOutActionTimer -= Time.deltaTime;
        if(m_FadeOutActionTimer <= 0)
        {
            fadeout = true;
        }


        if (fadeout == true)
        {
            FadeOut();
        }
    }

    

    void FadeOut()
    {
        alpha -= 0.01f;
        FadeColor.color = new Color(red,green,blue, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
        }
    }


}