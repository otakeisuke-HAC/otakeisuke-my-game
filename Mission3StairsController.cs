using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission3StairsController : MonoBehaviour
{
    public bool Mission3Flag = false;

    AudioSource m_AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mission3Flag == true)
        {
            transform.Rotate(-gameObject.transform.rotation.x, 0, 0);
        }
    }

    public void Mission3Clear()
    {
        Mission3Flag = true;
        m_AudioSource.Play();
    }
}
