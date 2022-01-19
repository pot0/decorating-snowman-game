using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowman : MonoBehaviour //BeforeRestart 씬에서 아이템 띄우고, Drag&Drop하는 코드
{
    GameObject tems;
    public GameObject[] tem = new GameObject[6]; //Drag&Drop 기능 넣어야 함. 아이템 저장 배열, main클래스의 bool 배열 참조하여 아이템 화면에 보여주기
    public GameObject[] face = new GameObject[2]; //Drag&Drop 기능 넣어야 함. 얼굴 아이템 저장 배열
    public bool[] herecollision = new bool[4];
    private void Awake() {
        tems = GameObject.Find("maintain"); //maintain 오브젝트 찾는다
        herecollision = tems.GetComponent<maintainNext>().temscollision; //maintainNext 스트립트에서 temscollision 불러옴
    }
    
    void Start()
    {
        FindTo();
    }
    void FindTo(){ //내가 먹은 아이템 표시
        for(int i=0; i<4; i++){

          Vector3 SpawnPoint = new Vector3(3.14f, -1.06f, 0f); //item[0] 위치

          if(herecollision[i]==false){ //닿은 적 있다면 생성
              switch(i){
                  case 0:
                    Instantiate(tem[i], SpawnPoint, Quaternion.Euler(0, 180.0f, 92.028f));
                    break;
                  case 1:
                    SpawnPoint = new Vector3(2.66f, -3.25f, 0f); //item[1] 위치
                    Instantiate(tem[i], SpawnPoint, Quaternion.Euler(0, 180.0f, 44.637f));
                    SpawnPoint = new Vector3(4.9f, -3.25f, 0f); //item[2] 위치
                    Instantiate(tem[i+1], SpawnPoint, Quaternion.Euler(0, 180.0f, -44.637f));
                    break;
                  case 2:
                    SpawnPoint = new Vector3(6.92f, -3.42f, 0f); //item[3] 위치
                    Instantiate(tem[i+1], SpawnPoint, Quaternion.Euler(0, 180.0f, 29.533f));
                    SpawnPoint = new Vector3(9.07f, -3.42f, 0f); //item[4] 위치
                    Instantiate(tem[i+2], SpawnPoint, Quaternion.Euler(0, 180.0f, -29f));
                    break;
                  case 3:
                    SpawnPoint = new Vector3(7.78f, -0.66f, 0f); //item[5] 위치
                    Instantiate(tem[i+2], SpawnPoint, Quaternion.identity);
                    break;
                }
            }  
        }
    }
}