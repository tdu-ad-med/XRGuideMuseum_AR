using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class RayCastMainScript : MonoBehaviour
{
    GameObject clickedGameObject;

    public GameObject MoonObject;

    //bool TexterOn = true;
    bool voiceon = true;
    static public bool texton1 = true;
    static public bool laungageon = true;

    static public bool worksmode =false;

    AudioSource audioSource2;
    public AudioClip sound1;
    public AudioClip sound1_2;

    public AudioClip sound_Book;
    public AudioClip sound_laungage;
    public AudioClip sound_Moon;


    //[SerializeField] private GameObject placementPrefab;
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    //ログ用のbool関数,一回判定するbool関数
    bool gimicJudgment =true;
    bool TextJudment = true;
    bool VoiceJudment = true;
    bool laungageJudment =true;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
        
        
    }

    public void Japanese()
    {
        GameObject cube7 = GameObject.Find("Worktext1");
        GameObject cube8 = GameObject.Find("Workmode1");
        if (MaterialChangeScript.i == 0)
        {
            cube7.GetComponent<Text>().text = "花咲くアーモンドの枝";
        }
        if (MaterialChangeScript.i == 1)
        {
            cube7.GetComponent<Text>().text = "アイリス";
        }
        if (MaterialChangeScript.i == 2)
        {
            cube7.GetComponent<Text>().text = "薔薇";
        }
        cube8.GetComponent<Text>().text = "戻る";

        GameObject cube5 = GameObject.Find("Text");
        GameObject cube6 = GameObject.Find("Theotext1");

        cube5.GetComponent<Text>().text = "サン＝レミのサン＝ポール療養院にゴッホが入院しているときに、窓から見える村の風景を描いたもの.天と地を接続している糸杉は、一般的に天国と関連して、死の架け橋の象徴とみなされている.また,ゴッホの過去の記憶がコラージュ的に表現されており現実的風景ではない.";
        cube6.GetComponent<Text>().text = "親愛なる弟　テオ";
    }
    public void English()
    {
        GameObject cube7 = GameObject.Find("Worktext1");
        GameObject cube8 = GameObject.Find("Workmode1");

        if (MaterialChangeScript.i == 0)
        {
            cube7.GetComponent<Text>().text = "Almond Blossoms";
        }
        if (MaterialChangeScript.i == 1)
        {
            cube7.GetComponent<Text>().text = "Iris";
        }
        if (MaterialChangeScript.i == 2)
        {
            cube7.GetComponent<Text>().text = "Rose";
        }
        cube8.GetComponent<Text>().text = "back";

        GameObject cube5 = GameObject.Find("Text");
        GameObject cube6 = GameObject.Find("Theotext1");

        cube5.GetComponent<Text>().text = "A picture of the village landscape seen through a window when Van Gogh was admitted to the Saint-Paul sanatorium in Saint-Remy. The cypress that connects heaven and earth is generally associated with heaven and died. It is regarded as a symbol of the bridge, and Van Gogh's past memories are expressed in a collage, which is not a realistic landscape.";
        cube6.GetComponent<Text>().text = "Dear MyBrother Theo";
    }

    // Update is called once per frame
    void Update()
    {

        if (SystemScript.ARStart == true)
        {
            if (count == 0)
            {
                if (SystemScript.japan == true)
                {
                    Japanese();
                }
                if (SystemScript.japan == false)
                {
                    English();
                }
                count = 1;
            }
        }

        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // rayを照射
            var ray = arCamera.ScreenPointToRay(touch.position);
            

            RaycastHit hit = new RaycastHit();
            clickedGameObject = null;
            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                
            }
            if (clickedGameObject.tag == "Moon")
            {
                if (gimicJudgment == true)
                {
                    clickedGameObject.GetComponent<Animator>().SetBool("MoonOn", true);
                    LogSystemScript.GimicLog += 1;
                    audioSource2.volume = 1.0f;
                    audioSource2.PlayOneShot(sound_Moon);
                    gimicJudgment = false;
                }

            }

            if (clickedGameObject.tag == "Works")
            {
                if (worksmode == false)
                {
                    GameObject cube5 = GameObject.Find("Worktext");
                    GameObject cube6 = GameObject.Find("Workmode");
                    GameObject cube7 = GameObject.Find("WorkMove");
                    cube6.GetComponent<Canvas>().enabled = true;
                    cube5.GetComponent<Canvas>().enabled = true;
                    cube7.GetComponent<Canvas>().enabled = true;
                    worksmode = true;
                    audioSource2.volume = 0.5f;
                    audioSource2.PlayOneShot(sound_Book);

                    return;
                }


            }
            if (clickedGameObject.tag == "Workmode")
            {
                GameObject cube5 = GameObject.Find("Worktext");
                GameObject cube6 = GameObject.Find("Workmode");
                GameObject cube7 = GameObject.Find("WorkMove");
                cube6.GetComponent<Canvas>().enabled = false;
                cube5.GetComponent<Canvas>().enabled = false;
                cube7.GetComponent<Canvas>().enabled = false;
                worksmode = false;
                audioSource2.volume = 0.5f;
                audioSource2.PlayOneShot(sound_Book);

                return;


            }

            if (clickedGameObject.tag == "Brother")
            {
                GameObject cube5 = GameObject.Find("Theotext");
                cube5.GetComponent<Canvas>().enabled = true;
            }
            if (clickedGameObject.tag == "Voice")
            {
                if (voiceon == true)
                {
                    if (VoiceJudment == true)
                    {
                        LogSystemScript.VoiceLog += 1;
                        VoiceJudment = false;
                    }


                    if (SystemScript.japan == false)
                    {
                        audioSource2.volume = 0.5f;
                        audioSource2.PlayOneShot(sound1);
                        voiceon = false;
                        GameObject.Find("Voiceicon").GetComponent<Renderer>().material.color = Color.white;
                        return;
                    }
                    if (SystemScript.japan == true)
                    {
                        audioSource2.volume = 1.0f;
                        audioSource2.PlayOneShot(sound1_2);
                        voiceon = false;
                        GameObject.Find("Voiceicon").GetComponent<Renderer>().material.color = Color.white;
                        return;
                    }
                }
                if (voiceon == false)
                {
                    VoiceJudment = true;
                    audioSource2.Stop();
                    voiceon = true;
                    GameObject.Find("Voiceicon").GetComponent<Renderer>().material.color = Color.gray;
                    return;
                }


            }

            if(clickedGameObject.tag == "Text")
            {
                GameObject cube2 = GameObject.Find("Texter");
                GameObject cube3 = GameObject.Find("Navi");
                GameObject cube4 = GameObject.Find("Navi_1");
                if (texton1 == true)
                {
                    if (TextJudment == true)
                    {
                        audioSource2.volume = 0.5f;
                        audioSource2.PlayOneShot(sound_Book);
                        LogSystemScript.TextLog += 1;
                        worksmode = false;
                        TextJudment = false;
                        
                    }
                    cube3.GetComponent<Canvas>().enabled = true;
                    cube2.GetComponent<Canvas>().enabled = true;
                    cube4.GetComponent<Canvas>().enabled = false;
                    TouchSampleScript.count = 0;
                    GameObject.Find("Texton").GetComponent<Renderer>().material.color = Color.white;
                    texton1 = false;
                    
                    return;
                }
                if(texton1 ==false)
                {
                    TextJudment = true;
                    cube2.GetComponent<Canvas>().enabled = false;
                    cube3.GetComponent<Canvas>().enabled = false;
                    cube4.GetComponent<Canvas>().enabled = true;
                    GameObject.Find("Texton").GetComponent<Renderer>().material.color = Color.gray;
                    texton1 = true;
                    audioSource2.volume = 0.5f;
                    audioSource2.PlayOneShot(sound_Book);
                    return;
                }

            }


            if (clickedGameObject.tag == "laungage")
            {
                if (laungageJudment == true)
                {
                    LogSystemScript.LaungageLog += 1;
                    laungageJudment = false;
                }
                GameObject cube3 = GameObject.Find("JapaneseMode");
                GameObject cube4 = GameObject.Find("EnglishMode");
                if (laungageon == true)
                {
                    GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.white;
                    
                    laungageon = false;
                    cube3.GetComponent<Canvas>().enabled = true;
                    cube4.GetComponent<Canvas>().enabled = true;
                    return;

                    
                }

                if (laungageon == false)
                {
                    laungageJudment = true;
                    GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.gray;
                    laungageon = true;
                    cube3.GetComponent<Canvas>().enabled = false;
                    cube4.GetComponent<Canvas>().enabled = false;
                    return;


                }
            }

            if (clickedGameObject.tag == "Back")
            {
                SceneManager.LoadScene("AR_Main");
            }


            /*
            if (TexterOn == false)
            {

                bool hasHit = Physics.Raycast(ray, out hit);
                if (hasHit)
                {
                    var target = hit.collider.gameObject;
                    if (target.name.Contains("Texter"))
                    {
                        LogSystemScript.WindowLog++;
                        Destroy(target);
                        TexterOn = true;
                        return;
                    }
                }
            }


            if (TexterOn == true)
            {
                var isHitPlane = raycastManager.Raycast(ray, raycastHits, TrackableType.PlaneWithinPolygon);
                if (isHitPlane)
                {
                    // 複数のPlaneがあった場合、最も近いPlaneが0番目に入っている
                    Pose pose = raycastHits[0].pose;
                    // 配置すべき座標
                    Vector3 placePosition = pose.position;
                    Instantiate(placementPrefab, placePosition, Quaternion.identity);
                    LogSystemScript.GimicLog++;
                    TexterOn = false;
                    return;
                }
            }
            */

        }

    }
}
