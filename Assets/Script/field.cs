﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class field : MonoBehaviour
{

    GameObject targetObj;
    GameObject Manager;
    Vector3 targetPos;
    


    GameObject Center;          // カメラやフィールドの回転の中心軸（の位置）
    GameObject StageManager;    // 各値が入ってるマネージャーを呼び出す
    manager script;             // マネージャーのスクリプト
	//bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない
	float cubeAngle = 0.0f;

    Bottun BottunScriptL;
    Bottun BottunScriptR;


    [SerializeField] public int AppearSlimeCount;  //生成するスライム数

    [SerializeField] public Vector3 SpawnSlimePos; //スライムごとの位置

    // Start is called before the first frame update
    void Start()
    {


        GameObject SmallSlime = (GameObject)Resources.Load("Prefab/SmallSlime");

        //フィールドの中心軸（の位置）を取得
        Center = GameObject.Find("FieldCenter");

        //ステージマネージャーの取得
        StageManager = GameObject.Find("StageManager");
        //マネージャーが持っているmanagerスクリプト
        script = StageManager.GetComponent<manager>();


        targetObj = GameObject.Find("FieldCenter");
        targetPos = targetObj.transform.position;

        Manager = GameObject.Find("StageManager");

        BottunScriptL = GameObject.Find("ButtonL").GetComponent<Bottun>();
        BottunScriptR = GameObject.Find("ButtonR").GetComponent<Bottun>();
    }

    // Update is called once per frame
    void Update()
    {

        // キーを押している間
        if (Input.anyKey)
		{
			// 移動量
			//float ToRotate = 0.0f;//Input.GetAxis("Mouse X");

			////==========================
			////　Z軸で左にステージが90度傾く
			////==========================
			//if (Input.GetKeyDown(KeyCode.RightArrow) && script.isCamera == false && script.isRotate == false)
			//{
			//	//trueで左回転
			//	script.SetTop(script.nowTop, true);
			//	StartCoroutine(MoveL());
			//	script.operations(-1);

			//}

			////==========================
			////　Z軸で右にステージが90度傾く
			////==========================
			//if (Input.GetKeyDown(KeyCode.LeftArrow) && script.isCamera == false && script.isRotate == false)
			//{
			//	//falseで右回転
			//	script.SetTop(script.nowTop, false);
			//	StartCoroutine(MoveR());
			//	script.operations(-1);
			//}
       }
        script.CheckBubble();
    }
	IEnumerator MoveR()
{
	//回転中のフラグを立てる
	script.isRotate = true;

	//回転処理
	float sumAngle = 0f; //angleの合計を保存
	while (sumAngle < 90f)
	{
		cubeAngle = 1.0f; //ここを変えると回転速度が変わる
		sumAngle += cubeAngle;

		// 90度以上回転しないように値を制限
		if (sumAngle >90f)
		{
			cubeAngle -= sumAngle - 90f;
		}
			switch (script.cameraRotate)
			{
				//カメラが正面にある場合
				case 0:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.forward,
						cubeAngle
					);
					break;

				//カメラが左側面にある場合
				case 1:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.left,
						cubeAngle
					);
					break;

				//カメラが後ろ面にある場合
				case 2:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.back,
						cubeAngle
					);
					break;

				//カメラが右側面にある場合
				case 3:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.right,
						cubeAngle
					);
					break;
			}


			yield return null;
	}

	//回転中のフラグを倒す
	script.isRotate = false;

	yield break;
}
	IEnumerator MoveL()
	{
		//回転中のフラグを立てる
		script.isRotate = true;

		//回転処理
		float sumAngle = 0f; //angleの合計を保存
		while (sumAngle > -90f)
		{
			cubeAngle = -1.0f; //ここを変えると回転速度が変わる
			sumAngle += cubeAngle;

			// 90度以上回転しないように値を制限
			if (sumAngle<-90.0f)
			{
				cubeAngle -= sumAngle + 90.0f;
			}
			switch (script.cameraRotate)
			{
				//カメラが正面にある場合
				case 0:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.forward,
						cubeAngle
					);
					break;

				//カメラが左側面にある場合
				case 1:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.left,
						cubeAngle
					);
					break;

					//カメラが後ろ面にある場合
				case 2:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.back,
						cubeAngle
					);
					break;

					//カメラが右側面にある場合
				case 3:

					transform.RotateAround
					(
						Center.transform.position,
						Vector3.right,
						cubeAngle
					);
					break;
			}

			yield return null;
		}

		//回転中のフラグを倒す
		script.isRotate = false;

		yield break;
	}

 public   IEnumerator RollYL()
    {

        //回転中のフラグを立てる
        script.isRotate = true;
        //回転処理
        float sumAngle = 0f; //angleの合計を保存

        while (sumAngle > -90f) {
            cubeAngle = -1.0f; //ここを変えると回転速度が変わる
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle < -90.0f) {
                cubeAngle -= sumAngle + 90.0f;
            }

            transform.RotateAround
                 (
                     Center.transform.position,
                     Vector3.up,
                     cubeAngle
                 );
            yield return null;
        }
        BottunScriptL.SetisClicked(false);

      

     
        //回転中のフラグを倒す
        script.isRotate = false;
        Mathf.Ceil(transform.rotation.x);
        Mathf.Ceil(transform.rotation.y);
        Mathf.Ceil(transform.rotation.z);
        yield break;
    }

   public IEnumerator RollYR()
    {

        //回転中のフラグを立てる
        script.isRotate = true;
        //回転処理
        float sumAngle = 0f; //angleの合計を保存

        while (sumAngle < 90f) {
            cubeAngle = 1.0f; //ここを変えると回転速度が変わる
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle > 90f) {
                cubeAngle -= sumAngle - 90f;
            }
            transform.RotateAround
                        (
                            Center.transform.position,
                            Vector3.up,
                            cubeAngle
                        );


            yield return null;
        }
        BottunScriptR.SetisClicked(false);
        //回転中のフラグを倒す
        script.isRotate = false;
        Mathf.Ceil(transform.rotation.x);
        Mathf.Ceil(transform.rotation.y);
        Mathf.Ceil(transform.rotation.z);
        yield break;
    }
    //IEnumerator RollY(bool LorR)
    //{

    //    //回転中のフラグを立てる
    //    script.isRotate = true;
    //    //回転処理
    //    float sumAngle = 0f; //angleの合計を保存

    //    while (sumAngle > -90f) {
    //        cubeAngle = -1.0f; //ここを変えると回転速度が変わる
    //        sumAngle += cubeAngle;

    //        // 90度以上回転しないように値を制限
    //        if (sumAngle < -90.0f) {
    //            cubeAngle -= sumAngle + 90.0f;
    //        }

    //        transform.RotateAround
    //             (
    //                 Center.transform.position,
    //                 Vector3.up,
    //                 cubeAngle
    //             );
    //        yield return null;
    //    }
    //    BottunScriptL.SetisClicked(false);


    //    while (sumAngle < 90f) {
    //        cubeAngle = 1.0f; //ここを変えると回転速度が変わる
    //        sumAngle += cubeAngle;

    //        // 90度以上回転しないように値を制限
    //        if (sumAngle > 90f) {
    //            cubeAngle -= sumAngle - 90f;
    //        }
    //        transform.RotateAround
    //                    (
    //                        Center.transform.position,
    //                        Vector3.up,
    //                        cubeAngle
    //                    );


    //        yield return null;
    //    }
    //    BottunScriptR.SetisClicked(false);


    //    //回転中のフラグを倒す
    //    script.isRotate = false;

    //    yield break;
    //}
}

