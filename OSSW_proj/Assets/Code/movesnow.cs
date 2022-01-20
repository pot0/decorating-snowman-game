using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movesnow : MonoBehaviour
{
    ItemDrop Item;
    lifescore life;
    public bool[] ITEMcollision = new bool[4]; //눈사람에 item이 닿았는가를 체크
    public float speed = 6;
    public Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();    
        life = FindObjectOfType<lifescore>();
        Item = FindObjectOfType<ItemDrop>();
    }
    void Start()
    {
        for(int i=0; i<4; i++){ //item 모두 true 상태로 설정 (어느 곳에도 닿지 않은 상태)
            ITEMcollision[i] = true;
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            rigid.AddForce(Vector2.right*speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rigid.AddForce(Vector2.left*speed);
        }        
        
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);

        float leftBorder = -13.6f + transform.localScale.x /2f;
        float rightBorder = 10.4f - transform.localScale.x /2f;

        if (worldpos.x < leftBorder) {worldpos.x = leftBorder;}
        if (worldpos.x > rightBorder) {worldpos.x = rightBorder;}

        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos); 
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag=="item"){ //아이템과 닿는다면
            Debug.Log("눈사람과 충돌  : " + Item.randomtem);
            Destroy(collision.gameObject); //충돌한아이템 오브젝트 삭제
            ITEMcollision[Item.randomtem] = false; //충돌 표시 false로 변경
            life.remain++; //먹은 아이템 수 증가
        }
    }
}