using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IEnumerator Inoperable(float i) // 操作を不能にする（引数の秒数間）
    {
        GameObject inputObj = GameObject.Find("Player");
        PlayerController playerController = inputObj.GetComponent<PlayerController>();
        playerController.enabled = false; // スクリプトを無効化
        yield return new WaitForSeconds(i); // 引数の秒数だけ待つ
        playerController.enabled = true; // スクリプトを有効化
        yield break;
    }

    public void CallInoperable(float i)
    {
        StartCoroutine("Inoperable", i); // 他のスクリプトから呼び出す用
    }
}