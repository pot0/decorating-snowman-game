using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    ItemDrop Item;
    void Start()
    {
        Item = FindObjectOfType<ItemDrop>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag=="item"){ //태그가 아이템인 오브젝트와 바닥이 닿는다면
            Debug.Log("바닥과 충돌  : " + Item.randomtem);
            Destroy(collision.gameObject); //충돌 오브젝트인 아이템 삭제
        }
    }
}