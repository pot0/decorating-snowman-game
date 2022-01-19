using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class maintainNext : MonoBehaviour //씬이 바뀌어도 유지될 클래스
{ 
    movesnow snow; //Gaming씬에서 움직이는 눈사람 클래스
    public GameObject collis;
    public bool[] temscollision = new bool[4]; //눈사람 충돌 여부 복사할 배열

    private void Awake() {
        snow = FindObjectOfType<movesnow>();
    }
    // Start is called before the first frame update
    void Start(){
        for(int i=0; i<4; i++){
            temscollision[i] = true; //배열 초기화
        }
        DontDestroyOnLoad(collis);
    }
    void Update() {
       for(int i=0; i<4; i++){
            temscollision[i] = snow.ITEMcollision[i]; //충돌 여부 복사
        }
    }
}