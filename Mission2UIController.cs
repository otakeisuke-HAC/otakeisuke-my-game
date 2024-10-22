using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission2UIController : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;
    public GameObject[] m_LeverObj;
    private int m_Lever = 3;
    private int m_LeverCount;

    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        m_LeverObj = GameObject.FindGameObjectsWithTag("Lever");
        if(m_LeverObj.Length < m_Lever)
        {
            m_Lever = m_LeverObj.Length;
            m_LeverCount++;
        }
        
        m_TextMeshProUGUI.text = "☆全てのレバーを起動せよ(" + m_LeverCount + "/3)";
    }
}
