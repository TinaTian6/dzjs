using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //物体移动值
    float x;
    float z;
    //物体刚体
    Rigidbody PlayerRigidbody;
    //物体旋转判定使用的射线
    Ray ray;
    //射线检测用的判断物体
    RaycastHit hit;
    //保存射线与地面交接的点位置
    Vector3 hitPosition;
    //LayerMesh层
    LayerMask planLayerMask;
    //摄像机
    GameObject cameraPosition;

	// Use this for initialization
	void Start () {
        //获取刚体
        PlayerRigidbody = gameObject.GetComponent<Rigidbody>();
        //cameraPosition = GameObject.FindGameObjectWithTag("CameraPosition");
        //实例化mask到cube这个自定义的层级之上（打开Plane层）
        planLayerMask = 1 << (LayerMask.NameToLayer("Plane"));

    }
	
	// Update is called once per frame
	void Update () {
        //物体移动
        Move();
        //物体旋转
        Rota();

    }

    void FixedUpdate()
    {


    }

    private void Move()
    {
        //获取我物体的移动
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //物体移动
        transform.Translate(new Vector3(0, 0, z) * 8 * Time.deltaTime, Space.Self);
        transform.RotateAround(transform.position, transform.up, x * 100 * Time.deltaTime);
        

    }

    private void Rota()
    {
        ////从屏幕发射一条射线
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ////进行射线检测
        //if (Physics.Raycast(ray, out hit, 200, planLayerMask.value))
        //{
        //    //获取所需要朝向的目标点（无Y值）
        //    hitPosition = hit.point;
        //    //让Y值保持原样
        //    hitPosition.y = transform.position.y;
        //    //朝向目标点
        //    transform.LookAt(hitPosition);


            //transform.rotation = Quaternion.Slerp(transform.rotation, mainCamera.transform.Find("CameraRotation").rotation, 2 * Time.deltaTime);
            //transform.forward = cameraPosition.transform.forward;

        //}


    }
}
