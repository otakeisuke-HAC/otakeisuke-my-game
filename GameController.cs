using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController Player;
    private SceneFadeManager f_GameController;
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        f_GameController = GetComponent<SceneFadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.m_HP <= 0)
        {
            GameOver.SetActive(true);
        }

        if(GameOver.activeSelf == true && Input.GetButtonDown("Submit"))
        {
            Retry();
        }
    }

    public void Retry()
    {
        f_GameController.fadeOutStart(0, 0, 0, 0, SceneManager.GetActiveScene().name);
    }
}
