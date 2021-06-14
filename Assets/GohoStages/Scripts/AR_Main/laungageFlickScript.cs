using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class laungageFlickScript : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool rightmode = false;
    bool leftmode = false;

    [Header("言語を変換するスクリプトがアタッチされているゲームオブジェクト")]
    public GameObject LaungageBox;
    public GameObject LaungageBox2;

    [Header("言語を決めた後のSE")]
    AudioSource audioSource2;
    public AudioClip sound_laungage;

    float laungagevolume = 0.2f;

    private void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "AR_Main")
        {
            if (RayCastMainScript.laungageon == false && RayCastMainScript.texton1 == true && RayCastMainScript.worksmode == false)
            {
                Flick();
            }
        }
        if (SceneManager.GetActiveScene().name == "AR_Main2")
        {
            if (RayCastScript2.laungageon2 == false && RayCastScript2.texton2 == true && RayCastScript2.worksmode2 == false)
            {
                Flick();
            }
        }

        if (rightmode == true)
        {

            GameObject cube3 = GameObject.Find("JapaneseMode");
            GameObject cube4 = GameObject.Find("EnglishMode");
            SystemScript.japan = false;
            GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.gray;
            cube3.GetComponent<Canvas>().enabled = false;
            cube4.GetComponent<Canvas>().enabled = false;
            if (SceneManager.GetActiveScene().name == "AR_Main")
            {
                LaungageBox.GetComponent<RayCastMainScript>().English();
            }
            if (SceneManager.GetActiveScene().name == "AR_Main2")
            {
                LaungageBox2.GetComponent<RayCastScript2>().English();
            }
            audioSource2.volume = laungagevolume;
            audioSource2.PlayOneShot(sound_laungage);
            
            if (SceneManager.GetActiveScene().name == "AR_Main")
            {
                RayCastMainScript.laungageon = true;
            }
            if (SceneManager.GetActiveScene().name == "AR_Main2")
            {
                RayCastScript2.laungageon2 = true;
            }
            rightmode = false;
            return;


        }
        if (leftmode == true)
        {
            GameObject cube3 = GameObject.Find("JapaneseMode");
           GameObject cube4 = GameObject.Find("EnglishMode");
            SystemScript.japan = true;
            GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.gray;
            cube3.GetComponent<Canvas>().enabled = false;
            cube4.GetComponent<Canvas>().enabled = false;
            if (SceneManager.GetActiveScene().name == "AR_Main")
            {
                LaungageBox.GetComponent<RayCastMainScript>().Japanese();
            }
            if (SceneManager.GetActiveScene().name == "AR_Main2")
            {
                LaungageBox2.GetComponent<RayCastScript2>().Japanese();
            }

            audioSource2.volume = laungagevolume;
            audioSource2.PlayOneShot(sound_laungage);//ここの部分が作動していない
            
            if (SceneManager.GetActiveScene().name == "AR_Main")
            {
                RayCastMainScript.laungageon = true;
            }
            if (SceneManager.GetActiveScene().name == "AR_Main2")
            {
                RayCastScript2.laungageon2 = true;
            }
            leftmode = false;
            return;
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
