using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaterialChangeScript : MonoBehaviour
{
    [Header("絵画の数及びマテリアル素材")]
    public Material[] _material;           // 割り当てるマテリアルの数
    static public int i;


    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool rightmode = false;
    bool leftmode = false;

    [Header("言語を変換するスクリプトがアタッチされているゲームオブジェクト")]
    public GameObject LaungageBox;
    public GameObject LaungageBox2;

    // Use this for initialization
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "AR_Main")
        {
            if (RayCastMainScript.laungageon == true && RayCastMainScript.texton1 == true && RayCastMainScript.worksmode == true)
            {
                Flick();
            }
        }
        if (SceneManager.GetActiveScene().name == "AR_Main2")
        {
            if (RayCastScript2.laungageon2 == true && RayCastScript2.texton2 == true && RayCastScript2.worksmode2 == true)
            {
                Flick();
            }
        }

        if (rightmode == true)
        {
            
            if (i == 3)
            {
                i = -1;
            }
            
            i++;
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
            if (SystemScript.japan == true)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    LaungageBox.GetComponent<RayCastMainScript>().Japanese();
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    LaungageBox2.GetComponent<RayCastScript2>().Japanese();
                }

            }
            if (SystemScript.japan == false)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    LaungageBox.GetComponent<RayCastMainScript>().English();
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    LaungageBox2.GetComponent<RayCastScript2>().English();
                }

            }
            rightmode = false;



        }
        if (leftmode == true)
        {
            
            if (i == 0)
            {
                i = 3;
            }
            
            i--;
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
            LogSystemScript.GimicLog++;
            if (SystemScript.japan == true)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    LaungageBox.GetComponent<RayCastMainScript>().Japanese();
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    LaungageBox2.GetComponent<RayCastScript2>().Japanese();
                }
            }
            if (SystemScript.japan == false)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    LaungageBox.GetComponent<RayCastMainScript>().English();
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    LaungageBox2.GetComponent<RayCastScript2>().English();
                }
            }
            leftmode = false;



        }

        void Flick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                touchStartPos = new Vector3(Input.mousePosition.x,
                                            Input.mousePosition.y,
                                            Input.mousePosition.z);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                touchEndPos = new Vector3(Input.mousePosition.x,
                                          Input.mousePosition.y,
                                          Input.mousePosition.z);
                GetDirection();
            }
        }

        void GetDirection()
        {
            float directionX = touchEndPos.x - touchStartPos.x;
            float directionY = touchEndPos.y - touchStartPos.y;
            //string Direction;



            if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
            {
                if (30 < directionX)
                {
                    //右向きにフリック

                    rightmode = true;
                }
                else if (-30 > directionX)
                {
                    //左向きにフリック
                    leftmode = true;
                }
            }
        }

    }
}
