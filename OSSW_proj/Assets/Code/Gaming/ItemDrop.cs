using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemDrop : MonoBehaviour {
    movesnow snow;
    lifescore life;
    public GameObject[] ITEM = new GameObject[4]; //item 담을 배열
    public int randomtem; //item을 뽑는 랜덤 수 저정할 변수
    float DestoryDelay = 5f;
    private IEnumerator coroutine;
    private void Awake() {
        life = FindObjectOfType<lifescore>();
        snow = FindObjectOfType<movesnow>();      
    }
	void Start () {
        //ITEM = GameObject.FindGameObjectsWithTag("item"); //item태그가 달린 오브젝트를 배열로 반환
        coroutine = SpawnITEM(DestoryDelay);
        StartCoroutine(coroutine);
    }
    IEnumerator SpawnITEM(float Delay){
        while(true){
            float delay = Random.Range(1f, 3.1f);
            yield return new WaitForSeconds(delay); 

            float SpawnX = Random.Range(-7f, 8f);//x위치 랜덤 
            Vector3 SpawnPoint = new Vector3(SpawnX, 4f, 0f); //스폰할 위치
            
            randomtem = Random.Range(0,4); //아이템 뽑기
            if (snow.ITEMcollision[randomtem]==true&&ITEM[randomtem].activeSelf==true) //item이 충돌한 적이 없는 상태이고, 활성화 상태라면
            {
                Debug.Log("생성 :" + randomtem);
                //아이템 랜덤 생성
                switch(randomtem) 
                {
                    case 0:
                        Instantiate(ITEM[0], SpawnPoint, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(ITEM[1], SpawnPoint, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(ITEM[2], SpawnPoint, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(ITEM[3], SpawnPoint, Quaternion.identity);
                        break;
                }               
            }
        }
    }
}