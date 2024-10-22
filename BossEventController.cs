using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEventController : MonoBehaviour
{
    public GameObject EventWall;
    public GameObject BossObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EventWall.activeSelf == true)
        {           
            if(EventWall.transform.position.y >= 54.1f)
            {
                EventWall.transform.Translate(0, 0, 0);
            }
            else
            {
                EventWall.transform.Translate(0, 0.5f, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventWall.SetActive(true);
            BossObj.SetActive(true);
        }
    }
}
