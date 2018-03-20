using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public float speed = 5;
    public float rotating = 10;
    private Animator a;



	void Start () {
        a = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");  
        float v = Input.GetAxis("Vertical");  
        transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0) * rotating * Time.deltaTime);
        if(h != 0||v !=0)
        {
            a.SetBool("RunBool", true);
            print("1");
        }else{
            a.SetBool("RunBool", false);
            print("2");
            print("3");
        }

    
    
    
    
    }
}
