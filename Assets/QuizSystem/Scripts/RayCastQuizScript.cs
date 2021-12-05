using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class RayCastQuizScript : MonoBehaviour
{
    
    [Header("AR System")]
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    GameObject clickedGameObject = null;

    //クイズスタート関数
    static public bool HokusaiQuiz = false;
    static public bool GohoQuiz = false;
    //クイズ数カウント
    static public int HokusaiQuizCount = 0;
    static public int GohoQuizCount = 0;
    //正解判定
    static public bool Collects = false;
    static public bool Falses = false;
    // Start is called before the first frame update
    void Start()
    {
        
        HokusaiQuizCount = 0;
        GohoQuizCount = 0;
        Collects = false;
        Falses = false;
        HokusaiQuiz = false;
        GohoQuiz = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // rayを照射
            var ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hit = new RaycastHit();
            //clickedGameObject = null;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    clickedGameObject = hit.collider.gameObject;
                }


            }
            if (hit.collider != null && clickedGameObject.tag == "Back")
            {
                SceneManager.LoadScene("AR_Main");
            }
            if (hit.collider != null && clickedGameObject.tag == "HokusaiQuizStage")
            {
                clickedGameObject.SetActive(false);
                GameObject cube1 = GameObject.Find("GohoStage");
                GameObject cube4 = GameObject.Find("Back_AR2");
                cube1.SetActive(false);             
                cube4.GetComponent<Renderer>().enabled = false;
                HokusaiQuiz = true;

            }
            if (hit.collider != null && clickedGameObject.tag == "GohoQuizStage")
            {
                clickedGameObject.SetActive(false);
                GameObject cube2 = GameObject.Find("HokusaiStage");
                GameObject cube4 = GameObject.Find("Back_AR2");
                cube2.SetActive(false);
                cube4.GetComponent<Renderer>().enabled = false;
                GohoQuiz = true;
            }
            if (hit.collider != null && clickedGameObject.tag == "A1")
            {
                if (HokusaiQuizCount == 0&&HokusaiQuiz==true)
                {
                    Debug.Log("正解！");
                    Collects = true;
                    HokusaiQuizCount = 1;
                    return;
                }
                if (HokusaiQuizCount == 1&&HokusaiQuiz == true)
                {
                    Debug.Log("不正解！");
                    Falses = true;
                    HokusaiQuizCount = 2;
                    return;

                }
                if (HokusaiQuizCount == 2&& HokusaiQuiz == true)
                {
                    Debug.Log("正解！");
                    Collects = true;
                    HokusaiQuizCount = 3;
                    return;
                }
                if (HokusaiQuizCount == 3&& HokusaiQuiz == true)
                {
                    SceneManager.LoadScene("AR_Quiz");

                    return;
                }
                if (GohoQuizCount == 0 && GohoQuiz == true)
                {
                    Debug.Log("正解！");
                    Collects = true;
                    GohoQuizCount = 1;
                    return;
                }
                if (GohoQuizCount == 1 && GohoQuiz == true)
                {
                    Debug.Log("不正解！");
                    Falses = true;
                    GohoQuizCount = 2;
                    return;

                }
                if (GohoQuizCount == 2 && GohoQuiz == true)
                {
                    Debug.Log("正解！");
                    Collects = true;
                    GohoQuizCount = 3;
                    return;
                }
                if (GohoQuizCount == 3 && GohoQuiz == true)
                {
                    SceneManager.LoadScene("AR_Quiz");

                    return;
                }
            }
            if (hit.collider != null && clickedGameObject.tag == "A2")
            {
                if (HokusaiQuizCount == 0 && HokusaiQuiz == true)
                {
                    Debug.Log("不正解！");
                    Falses = true;
                    HokusaiQuizCount = 1;
                    return;
                }
                if (HokusaiQuizCount == 1 && HokusaiQuiz == true)
                {
                    Debug.Log("正解！");
                    Collects = true;
                    HokusaiQuizCount = 2;
                    return;
                }
                if (HokusaiQuizCount == 2 && HokusaiQuiz == true)
                {
                    Debug.Log("不正解！");
                    Falses = true;
                    HokusaiQuizCount = 3;
                    return;
                }
                if (HokusaiQuizCount == 3 && HokusaiQuiz == true)
                {
                    SceneManager.LoadScene("AR_Main");
                    return;
                }
                if (GohoQuizCount == 0 && GohoQuiz == true)
                {
                    Debug.Log("不正解！");
                    Falses = true;
                    GohoQuizCount = 1;
                    return;
                }
                if (GohoQuizCount == 1 && GohoQuiz == true)
                {
                    Debug.Log("正解！");
                    Collects = true;
                    GohoQuizCount = 2;
                    return;
                }
                if (GohoQuizCount == 2 && GohoQuiz == true)
                {
                    Debug.Log("不正解！");
                    Falses = true;
                    GohoQuizCount = 3;
                    return;
                }
                if (GohoQuizCount == 3 && GohoQuiz == true)
                {
                    SceneManager.LoadScene("AR_Main");
                    return;
                }
            }
        }
     }
  
}
