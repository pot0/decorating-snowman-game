using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    GameObject nex;

    private void Awake() {
        nex = GameObject.Find("maintain"); //maintain 오브젝트 찾는다
        Destroy(nex);
    }
    private void Start() {

    }

    public void SceneChange()
    {
        {
            SceneManager.LoadScene("InGame");
        }
    }
}
