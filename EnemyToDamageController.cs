using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToDamageController : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyObj;
    [SerializeField]
    GameObject PlayerObj;
    // Start is called before the first frame update
    void Start()
    {
        EnemyObj = transform.root.gameObject;
        PlayerObj = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.gameObject.GetComponent<PlayerController>().m_Animator.GetBool("BlockBool") == false)
        {
            other.gameObject.GetComponent<PlayerController>().Damage();
            Debug.Log("hhh");
        }else if(other.gameObject.CompareTag("Player") 
            && other.gameObject.GetComponent<PlayerController>().m_Animator.GetBool("BlockBool") == true)
        {
            other.gameObject.GetComponent<PlayerController>().BlockDamage();
            Debug.Log("kkkk");
        }
    }
}
