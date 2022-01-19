using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ingamesnowball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            rigid.AddForce(Vector2.right*speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rigid.AddForce(Vector2.left*speed);
        }        

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Gaming");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("Helping");
        }      
    }
}
