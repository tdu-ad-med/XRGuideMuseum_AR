using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RaycastScript : MonoBehaviour
{
    GameObject clickedGameObject;
    public GameObject BrotherUI;
    public GameObject AnotherUI;

    AudioSource audioSource;
    public AudioClip sound1;

    bool Windowstouch = true;

  //Logを正確にとるためのbool判定
  bool gimicJudgment = true;
   bool WindowJudment = true;

    [SerializeField]

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        WindowJudment = true;
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;

            }

            if (Windowstouch == true)
            {
                if (clickedGameObject.tag == "windows")
                {
                    if (WindowJudment == true)
                    {
                        LogSystemScript.WindowLog += 1;
                        WindowJudment = false;
                    }
                    SceneManager.LoadScene("Gohho_World");
                    
                }
            }

            if (clickedGameObject.tag == "brother")
            {
                audioSource.PlayOneShot(sound1);
                BrotherUI.SetActive(true);

                if (gimicJudgment == true)
                {
                    LogSystemScript.GimicLog += 1;
                    gimicJudgment = false;
                }
                Windowstouch = false;

            }
            if (clickedGameObject.tag == "another")
            {
                audioSource.PlayOneShot(sound1);
                AnotherUI.SetActive(true);
                if (gimicJudgment == true)
                {
                    LogSystemScript.GimicLog += 1;
                    gimicJudgment = false;
                }
                Windowstouch = false;
            }
        }


        if (Input.touchCount > 0)
        {
            // タッチ情報の取得
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    clickedGameObject = hit.collider.gameObject;
                    

                }

                if (Windowstouch == true)
                {
                    if (clickedGameObject.tag == "windows")
                    {

                        SceneManager.LoadScene("Gohho_World");
                    }
                }

                if (clickedGameObject.tag == "brother")
                {
                    Windowstouch = false;
                    audioSource.PlayOneShot(sound1);
                    BrotherUI.SetActive(true);

                }
                if (clickedGameObject.tag == "another")
                {
                    Windowstouch = false;
                    audioSource.PlayOneShot(sound1);
                    AnotherUI.SetActive(true);

                }
            }

        }

    }

    public void Return()
    {
        AnotherUI.SetActive(false);
        BrotherUI.SetActive(false);
        Windowstouch = true;
        audioSource.PlayOneShot(sound1);
        gimicJudgment = true;
    }
}
