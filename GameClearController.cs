using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour
{
    public GameObject GameController;
    private SceneFadeManager f_GameController;
    // Start is called before the first frame update
    void Start()
    {
        f_GameController = GameController.GetComponent<SceneFadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            f_GameController.fadeOutStart(0, 0, 0, 0,"GameClearScene");

        }
    }
}
