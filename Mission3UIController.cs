using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission3UIController : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;
    public GameObject[] m_SkeletonObj;
    private int m_Skeleton = 3;
    private int m_SkeletonCount;
    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_SkeletonObj = GameObject.FindGameObjectsWithTag("Lever");
        if (m_SkeletonObj.Length < m_Skeleton)
        {
            m_Skeleton = m_SkeletonObj.Length;
            m_SkeletonCount++;
        }

        m_TextMeshProUGUI.text = "™ƒXƒPƒ‹ƒgƒ“‚ð“|‚¹(" + m_SkeletonCount + "/3)";
    }
}
