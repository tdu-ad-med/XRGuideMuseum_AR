using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;


public class RayCastMainScript : MonoBehaviour
{
    GameObject clickedGameObject=null;

    public GameObject MoonObject;

    //bool voiceon = true;
    static public bool texton1 = true;
    static public bool laungageon = true;

    static public bool worksmode =false;

    AudioSource audioSource2;
    [Header("英語ガイドボイス")]
    //public AudioClip sound1;//English
    [Header("日本語ガイドボイス")]
    public AudioClip sound1_2;//japanese

    [Header("SE")]
    public AudioClip sound_Book;
    //public AudioClip sound_laungage;
    public AudioClip sound_Moon;
    public AudioClip sound_Wing;


    //[SerializeField] private GameObject placementPrefab;
    [Header("AR System")]
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    //ログ用のbool関数,一回判定するbool関数
    bool gimicJudgment =true;
    bool TextJudment = true;

    //bool laungageJudment =true;
    bool gimic2judment = true;
    bool gimic3judment = true;
    bool communicatejudment = true;

    //音量調節
    //float sound_japanese_volume = 1.0f;
    //float sound_English_volume = 0.5f;
    float sound_Book_volume = 0.5f;
    float sound_moon_volume = 1.0f;

    public Material mat1;//再生ボタン
    public Material mat2;//停止ボタン

    private Coroutine _currentCoroutine;

    [Header("時間計測")]
    static public bool timer_GohoMOvieJudgment = false;
    static public bool timer_GohoAnotherWorkjudgment = false;
    static public bool timer_GohoCommunicationjudgment = false;


    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
        
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
                if (hit.collider != null&&clickedGameObject.tag == "Moon")
                {
                    if (gimicJudgment == true)
                    {
                        clickedGameObject.GetComponent<Animator>().SetBool("MoonOn", true);
                        LogSystemScript.GimicLog += 1;
                        audioSource2.volume = sound_moon_volume;
                        audioSource2.PlayOneShot(sound_Moon);
                        gimicJudgment = false;
                    }

                }

                if (hit.collider != null && clickedGameObject.tag == "Works")
                {
                    if (worksmode == false)
                    {
                        GameObject cube5 = GameObject.Find("Worktext");
                        GameObject cube6 = GameObject.Find("Workmode");
                        GameObject cube7 = GameObject.Find("WorkMove");
                        cube6.GetComponent<Canvas>().enabled = true;
                        cube5.GetComponent<Canvas>().enabled = true;
                        cube7.GetComponent<Canvas>().enabled = true;
                        audioSource2.volume = sound_Book_volume;
                        audioSource2.PlayOneShot(sound_Book);
                        LogSystemScript.VoiceLog++;
                        timer_GohoAnotherWorkjudgment = true;
                        worksmode = true;
                        laungageon = true;
                        texton1 = true;
                        return;
                    }


                }
                if (hit.collider != null && clickedGameObject.tag == "Workmode")
                {
                    GameObject cube5 = GameObject.Find("Worktext");
                    GameObject cube6 = GameObject.Find("Workmode");
                    GameObject cube7 = GameObject.Find("WorkMove");
                    cube6.GetComponent<Canvas>().enabled = false;
                    cube5.GetComponent<Canvas>().enabled = false;
                    cube7.GetComponent<Canvas>().enabled = false;
                    timer_GohoAnotherWorkjudgment = false;
                    Debug.Log("ゴッホの他の作品の鑑賞時間" + GohoTimerScript.timer_GohoAnotherWork.ToString("f0") + "秒");
                    GohoTimerScript.timer_GohoAnotherWork = 0;
                    worksmode = false;
                    audioSource2.volume = sound_Book_volume;
                    audioSource2.PlayOneShot(sound_Book);

                    return;


                }

                if (hit.collider != null && clickedGameObject.tag == "Brother")
                {
                    if (gimic3judment == true)
                    {
                        GameObject cube5 = GameObject.Find("Theotext");
                        GameObject cube6 = GameObject.Find("Theotext1");
                        cube5.GetComponent<Canvas>().enabled = true;
                        audioSource2.volume = sound_Book_volume;
                        audioSource2.PlayOneShot(sound_Book);
                    if (SystemScript.japan == true)
                    {
                        cube6.GetComponent<Text>().text = "親愛なる弟　テオ";
                    }

                    if (SystemScript.japan == false)
                    {
                        cube6.GetComponent<Text>().text = "Dear MyBrother Theo";
                    }
                    LogSystemScript.WindowLog++;
                        gimic3judment = false;
                    }
                }

                if (hit.collider != null && clickedGameObject.tag == "Text")
                {
                    GameObject cube2 = GameObject.Find("Texter");
                    GameObject cube3 = GameObject.Find("Texter2");
                    GameObject cube10 = GameObject.Find("ReplayButon");
                    GameObject cube11 = GameObject.Find("Back_AR2");
                    GameObject cube13 = GameObject.Find("CommunicationButton");
                    GameObject cube21 = GameObject.Find("GuideAnimation1");
                    GameObject cube22 = GameObject.Find("GuideAnimation2");
                    GameObject cube23 = GameObject.Find("GuideAnimation3");
                    GameObject cube24 = GameObject.Find("GuideAnimation4");
                    GameObject cube25 = GameObject.Find("GuideAnimation5");
                    GameObject cube26 = GameObject.Find("GuideAnimation6");


                    if (texton1 == true)
                    {
                        if (TextJudment == true)
                        {
                            worksmode = false;
                            TextJudment = false;
                        }

                        cube2.GetComponent<Canvas>().enabled = true;
                        cube3.GetComponent<Canvas>().enabled = true;
                        cube10.GetComponent<Renderer>().material = mat2;
                        cube11.GetComponent<Renderer>().enabled = false;
                        cube13.GetComponent<Renderer>().enabled = false;
                        audioSource2.PlayOneShot(sound1_2);
                        timer_GohoMOvieJudgment = true;
                        if (_currentCoroutine == null)
                        {
                            _currentCoroutine = StartCoroutine(GohoGuide());

                        }


                        LogSystemScript.TextLog += 1;
                        laungageon = true;
                        texton1 = false;
                        return;
                    }
                    if (texton1 == false)
                    {
                        TextJudment = true;
                        cube2.GetComponent<Canvas>().enabled = false;
                        cube3.GetComponent<Canvas>().enabled = false;
                        cube11.GetComponent<Renderer>().enabled = true;
                        cube10.GetComponent<Renderer>().material = mat1;
                        cube13.GetComponent<Renderer>().enabled = true;
                        audioSource2.Stop();

                        timer_GohoMOvieJudgment = false;
                        Debug.Log("ゴッホのガイド鑑賞時間" + GohoTimerScript.timer_GohoMovie.ToString("f0") + "秒");
                        GohoTimerScript.timer_GohoMovie = 0;
                        cube21.GetComponent<Renderer>().enabled = false;
                        cube22.GetComponent<Renderer>().enabled = false;
                        cube21.GetComponent<Animator>().SetBool("GohoAnimation1On", false);
                        cube22.GetComponent<Animator>().SetBool("GohoAnimation2On", false);
                        cube23.GetComponent<Canvas>().enabled = false;
                        cube24.GetComponent<Canvas>().enabled = false;
                        cube25.GetComponent<Canvas>().enabled = false;
                        cube26.GetComponent<Canvas>().enabled = false;


                        if (_currentCoroutine != null)
                        {
                            // 実行中のコルーチンを停止（破棄）
                            StopCoroutine(_currentCoroutine);
                            _currentCoroutine = null;
                        }

                        texton1 = true;

                        return;
                    }

                }


                if (hit.collider != null && clickedGameObject.tag == "Back")
                {
                    if (SceneManager.GetActiveScene().name == "AR_Main")
                    {
                        SceneManager.LoadScene("AR_Main");
                    }
                    else if (SceneManager.GetActiveScene().name == "AR_Main2")
                    {
                        SceneManager.LoadScene("AR_Main2");
                    }
                }

                if (hit.collider != null && clickedGameObject.tag == "Wave")
                {

                    if (gimic2judment == true)
                    {
                        GameObject cube7 = GameObject.Find("particle_1");
                        GameObject cube8 = GameObject.Find("particle_2");
                        cube7.GetComponent<ParticleSystem>().Play();
                        cube8.GetComponent<ParticleSystem>().Play();
                        audioSource2.volume = sound_moon_volume;
                        audioSource2.PlayOneShot(sound_Wing);
                        LogSystemScript.GimicLog++;
                        gimic2judment = false;
                    }
                }
                if (hit.collider != null && clickedGameObject.tag == "Voice")
                {
                    GameObject cube30 = GameObject.Find("ReplayButon");
                    GameObject cube31 = GameObject.Find("Back_AR2");
                    GameObject cube32 = GameObject.Find("CommentGroup");
                    GameObject cube33 = GameObject.Find("chattext");
                    GameObject cube37 = GameObject.Find("Cloud_image");
                    GameObject cube34 = GameObject.Find("CommunicationButton");
                    GameObject cube35 = GameObject.Find("Editor");
                    GameObject cube36 = GameObject.Find("Back_2");

                    if (communicatejudment == true)
                    {
                        cube30.GetComponent<Renderer>().enabled = false;
                        cube31.GetComponent<Renderer>().enabled = false;
                        cube32.GetComponent<Canvas>().enabled = true;
                        cube34.GetComponent<Renderer>().enabled = false;
                        cube35.GetComponent<Renderer>().enabled = true;
                        cube36.GetComponent<Renderer>().enabled = true;
                        LogSystemScript.CommunicationLog++;
                        timer_GohoCommunicationjudgment = true;

                        if (InputTextScript.CommentStart == true)
                        {
                            cube37.GetComponent<Image>().enabled = true;
                            cube33.GetComponent<Text>().text = InputTextScript.CommentSave;
                        }
                        communicatejudment = false;
                        return;
                    }


                }
                if (hit.collider != null && clickedGameObject.tag == "Back2")
                {
                    GameObject cube30 = GameObject.Find("ReplayButon");
                    GameObject cube31 = GameObject.Find("Back_AR2");
                    GameObject cube32 = GameObject.Find("CommentGroup");
                    GameObject cube34 = GameObject.Find("CommunicationButton");
                    GameObject cube35 = GameObject.Find("Editor");
                    GameObject cube36 = GameObject.Find("Back_2");
                    cube30.GetComponent<Renderer>().enabled = true;
                    cube31.GetComponent<Renderer>().enabled = true;
                    cube32.GetComponent<Canvas>().enabled = false;
                    cube34.GetComponent<Renderer>().enabled = true;
                    cube35.GetComponent<Renderer>().enabled = false;
                    cube36.GetComponent<Renderer>().enabled = false;
                    communicatejudment = true;
                    timer_GohoCommunicationjudgment = false;
                    Debug.Log("ゴッホのコミュニケーションツールを閲覧した時間" + GohoTimerScript.timer_GohoCommunication.ToString("f0") + "秒");
                    GohoTimerScript.timer_GohoCommunication = 0;

            }
                if (hit.collider != null && clickedGameObject.tag == "Editor")
                {
                    SceneManager.LoadScene("Communication");
                }
            

        }




    }
    IEnumerator GohoGuide()
    {
        GameObject cube20 = GameObject.Find("Text_G1");
        GameObject cube21 = GameObject.Find("GuideAnimation1");
        GameObject cube22 = GameObject.Find("GuideAnimation2");
        GameObject cube23 = GameObject.Find("GuideAnimation3");
        GameObject cube24 = GameObject.Find("GuideAnimation4");
        GameObject cube25 = GameObject.Find("GuideAnimation5");
        GameObject cube26 = GameObject.Find("GuideAnimation6");
        cube20.GetComponent<Text>().text = "星月夜\nゴッホ";
        //5秒停止
        yield return new WaitForSeconds(5);

        cube20.GetComponent<Text>().text = "この作品は、サン＝レミのサンポール療養院にゴッホが入院している時に窓から見える村の風景を描いたものです";
        cube21.GetComponent<Renderer>().enabled = true;
        cube22.GetComponent<Renderer>().enabled = true;

        cube21.GetComponent<Animator>().SetBool("GohoAnimation1On", true);
        cube22.GetComponent<Animator>().SetBool("GohoAnimation2On", true);

        yield return new WaitForSeconds(10);
        cube21.GetComponent<Renderer>().enabled = false;
        cube22.GetComponent<Renderer>().enabled = false;
        cube21.GetComponent<Animator>().SetBool("GohoAnimation1On", false);
        cube22.GetComponent<Animator>().SetBool("GohoAnimation2On", false);
        cube23.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "実際の絵画をみてみましょう\n(実物と見比べましょう)";

        yield return new WaitForSeconds(5);
        cube23.GetComponent<Canvas>().enabled = false;
        cube24.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "天と地を接続している糸杉は、一般的に天国と関連して、死の架け橋の象徴とみなされています";

        yield return new WaitForSeconds(10);

        cube20.GetComponent<Text>().text = "また、ゴッホの記憶がコラージュ的に表現されており、現実的風景ではありません";
        cube24.GetComponent<Canvas>().enabled = false;
        
        yield return new WaitForSeconds(10);
        cube25.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "例えば、中央に見える教会はフランスの教会ではなく、ゴッホの故郷であるオランダの教会が描かれています";

        yield return new WaitForSeconds(10);
        cube25.GetComponent<Canvas>().enabled = false;
        cube26.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "巨大な星々も、当時夜明けの空に見えた金星をイメージしたと考えられており、空想を織り交ぜた描写と言えるでしょう";

        yield return new WaitForSeconds(15);
        cube26.GetComponent<Canvas>().enabled = false;

        GameObject cube2 = GameObject.Find("Texter");
        GameObject cube3 = GameObject.Find("Texter2");
        GameObject cube10 = GameObject.Find("ReplayButon");
        GameObject cube11 = GameObject.Find("Back_AR2");
        GameObject cube34 = GameObject.Find("CommunicationButton");
        TextJudment = true;
        cube2.GetComponent<Canvas>().enabled = false;
        cube3.GetComponent<Canvas>().enabled = false;
        cube11.GetComponent<Renderer>().enabled = true;
        cube10.GetComponent<Renderer>().material = mat1;
        cube34.GetComponent<Renderer>().enabled = true;
        audioSource2.Stop();
        timer_GohoMOvieJudgment = false;
        Debug.Log("ゴッホのガイド鑑賞時間" + GohoTimerScript.timer_GohoMovie.ToString("f0")+"秒");
        GohoTimerScript.timer_GohoMovie = 0;
        texton1 = true;
        if (_currentCoroutine != null)
        {
            // 実行中のコルーチンを停止（破棄）
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
        yield break;
    }
}
