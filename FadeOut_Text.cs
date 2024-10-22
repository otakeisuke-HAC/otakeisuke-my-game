using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeOut_Text : MonoBehaviour
{


    public GameObject Textfade;   //�t�F�[�h�e�L�X�g�̎擾

    TextMeshProUGUI FadeColor;  //�t�F�[�h�e�L�X�g�̎擾�ϐ�
    
    private float alpha ,red, green, blue;  //RGBA�擾�ϐ�

    private bool fadeout;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    public float m_FadeOutActionTimer;            //�V�[���̈ړ���i���o�[�擾�ϐ�


    // Use this for initialization
    void Start()
    {

        FadeColor = GetComponent<TextMeshProUGUI>(); //�e�L�X�g���擾
        
        alpha = FadeColor.color.a;                 //�p�l����alpha�l���擾
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