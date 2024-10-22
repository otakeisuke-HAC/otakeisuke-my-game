using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchManager : MonoBehaviour
{
    public GameObject s_PlayerObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            s_PlayerObj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            s_PlayerObj = null;
        }
    }

}
