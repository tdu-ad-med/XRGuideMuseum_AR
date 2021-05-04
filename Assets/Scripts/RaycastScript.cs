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

    [SerializeField]

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                    //Debug.Log(clickedGameObject);
                    SceneManager.LoadScene("AR_Sample");
                    LogSystemScript.WindowLog += 1;
                }
            }

            if (clickedGameObject.tag == "brother")
            {
                audioSource.PlayOneShot(sound1);
                BrotherUI.SetActive(true);
                LogSystemScript.GimicLog += 1;
                Windowstouch = false;

            }
            if (clickedGameObject.tag == "another")
            {
                audioSource.PlayOneShot(sound1);
                AnotherUI.SetActive(true);
                LogSystemScript.GimicLog += 1;
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

                        SceneManager.LoadScene("AR_Sample");
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
    }
}
