using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class lifescore : MonoBehaviour
{
    public Text life;
    public int remain;
    float timer;
    int waitingtime;
    void Start()
    {
        timer = 0.0f;
        waitingtime = 2;
        remain = 0;
        life.text = "" + remain;
    }
    void Update()
    {
        life.text = "" + remain;            
        if (remain >= 3) //눈사람이 아이템 3개를 먹으면
        {
            timer += Time.deltaTime;
             //3초 후 장면 전환 함수 호출
            if(timer > waitingtime) {
                SceneChange();
            }
        }
    }
        public void SceneChange()
    {
        {
            SceneManager.LoadScene("BeforeRestart");
        }
    }
}
