using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSceneController : MonoBehaviour
{
    private SceneFadeManager f_GameController;
    // Start is called before the first frame update
    void Start()
    {
        f_GameController = gameObject.GetComponent<SceneFadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack"))
        {
            f_GameController.fadeOutStart(0, 0, 0, 0, "TitleScene");
        }
    }
}
