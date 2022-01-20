using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMan : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();    

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
}
