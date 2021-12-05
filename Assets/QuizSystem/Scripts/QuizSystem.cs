using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizSystem : MonoBehaviour
{
    public GameObject UI1;
    static public int QuizCount = 0;
    //一回処理用
    int count_1 = 0;
    int count_2 = 0;
    //int count_3 = 0;
    //int count_4 = 0;
    //正解数管理用
    int count_collect = 0;

    //音管理
    AudioSource audioSource2;
    AudioSource audioSource3;
    public AudioClip audioClip1;//デデン！
    public AudioClip audioClip2;//ピンポン
    public AudioClip audioClip3;//不正解
    public AudioClip audioClip4;//結果


    // Start is called before the first frame update
    void Start()
    {
        QuizCount = 0;
        audioSource2 = GetComponent<AudioSource>();
        audioSource3 = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagScript4.ARQuizOn == true&&count_1==0)
        {
            UI1.SetActive(false);
            count_1 = 1;
        }
        if (RayCastQuizScript.HokusaiQuiz == true&&count_2==0)
        {
            StartCoroutine("HokusaiQuizStart_1");
            count_2 = 1;
        }
        if (RayCastQuizScript.GohoQuiz == true && count_2 == 0)
        {
            StartCoroutine("GohoQuizStart_1");
            count_2 = 1;
        }
        if (RayCastQuizScript.Collects==true)
        {
            StartCoroutine("QuizTrue");
            RayCastQuizScript.Collects = false;
        }
        if (RayCastQuizScript.Falses == true)
        {
            StartCoroutine("QuizFalse");
            RayCastQuizScript.Falses = false;
        }

    }
    IEnumerator HokusaiQuizStart_1()
    {
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().text = "北斎のクイズスタート！";
        audioSource2.clip = audioClip1;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().text = "今回選んだ絵画の作品名を答えよ";
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = true;
        cube3.GetComponent<BoxCollider>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<BoxCollider>().enabled = true;
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "神奈川沖浪浦";
        cube12.GetComponent<Text>().text = "富嶽三十六景";
        audioSource3.Play();
        yield break;
    }
    IEnumerator QuizTrue()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<BoxCollider>().enabled = false;
        cube5.GetComponent<BoxCollider>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().text = "正解！";
        cube10.GetComponent<Text>().fontSize = 200;
        GameObject cube11 = GameObject.Find("TrueIcon");
        cube11.GetComponent<Renderer>().enabled = true;
        count_collect++;
        audioSource2.clip = audioClip2;
        audioSource2.Play();
        audioSource3.Stop();
        yield return new WaitForSeconds(5);
        cube3.GetComponent<BoxCollider>().enabled = true;
        cube5.GetComponent<BoxCollider>().enabled = true;
        cube10.GetComponent<Text>().fontSize = 120;
        cube11.GetComponent<Renderer>().enabled = false;
        if (QuizCount == 0&&RayCastQuizScript.HokusaiQuiz==true)
        {
            StartCoroutine("HokusaiQuizStart_2");
            QuizCount = 1;
            yield break;
        }
        if (QuizCount == 1 && RayCastQuizScript.HokusaiQuiz == true)
        {
            StartCoroutine("HokusaiQuizStart_3");
            QuizCount = 2;
            yield break;
        }
        if (QuizCount == 2 && RayCastQuizScript.HokusaiQuiz == true)
        {
            StartCoroutine("HokusaiResult");
            yield break;
        }
        if (QuizCount == 0 && RayCastQuizScript.GohoQuiz == true)
        {
            StartCoroutine("GohoQuizStart_2");
            QuizCount = 1;
            yield break;
        }
        if (QuizCount == 1 && RayCastQuizScript.GohoQuiz == true)
        {
            StartCoroutine("GohoQuizStart_3");
            QuizCount = 2;
            yield break;
        }
        if (QuizCount == 2 && RayCastQuizScript.GohoQuiz == true)
        {
            StartCoroutine("GohoResult");
            yield break;
        }

    }
    IEnumerator QuizFalse()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<BoxCollider>().enabled = false;
        cube5.GetComponent<BoxCollider>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().text = "不正解！";
        cube10.GetComponent<Text>().fontSize = 200;
        GameObject cube11 = GameObject.Find("FalseIcon");
        cube11.GetComponent<Renderer>().enabled = true;
        audioSource2.clip = audioClip3;
        audioSource2.Play();
        audioSource3.Stop();
        yield return new WaitForSeconds(5);
        cube10.GetComponent<Text>().fontSize = 120;
        cube11.GetComponent<Renderer>().enabled = false;
        cube3.GetComponent<BoxCollider>().enabled = true;
        cube5.GetComponent<BoxCollider>().enabled = true;
        if (QuizCount == 0 && RayCastQuizScript.HokusaiQuiz == true)
        {
            StartCoroutine("HokusaiQuizStart_2");
            QuizCount = 1;
            yield break;
        }
        if (QuizCount == 1 && RayCastQuizScript.HokusaiQuiz == true)
        {
            StartCoroutine("HokusaiQuizStart_3");
            QuizCount = 2;
            yield break;
        }
        if (QuizCount == 2 && RayCastQuizScript.HokusaiQuiz == true)
        {
            StartCoroutine("HokusaiResult");
            yield break;
        }
        if (QuizCount == 0 && RayCastQuizScript.GohoQuiz == true)
        {
            StartCoroutine("GohoQuizStart_2");
            QuizCount = 1;
            yield break;
        }
        if (QuizCount == 1 && RayCastQuizScript.GohoQuiz == true)
        {
            StartCoroutine("GohoQuizStart_3");
            QuizCount = 2;
            yield break;
        }
        if (QuizCount == 2 && RayCastQuizScript.GohoQuiz == true)
        {
            StartCoroutine("GohoResult");
            yield break;
        }

    }
    IEnumerator HokusaiQuizStart_2()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = false;
        cube5.GetComponent<Canvas>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().fontSize = 200;
        cube10.GetComponent<Text>().text = "次の問題！";
        audioSource2.clip = audioClip1;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().fontSize = 120;
        cube3.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        cube10.GetComponent<Text>().text = "当時どんな色が流行っていたか";
        audioSource3.Play();
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "オーシャンブルー";
        cube12.GetComponent<Text>().text = "プルシャンブルー";
        yield break;
    }
    IEnumerator HokusaiQuizStart_3()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = false;
        cube5.GetComponent<Canvas>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().fontSize = 200;
        cube10.GetComponent<Text>().text = "最後の問題！";
        audioSource2.clip = audioClip1;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().fontSize = 120;
        cube3.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        cube10.GetComponent<Text>().text = "北斎の他の作品として\n当てはまるものはどれか";
        audioSource3.Play();
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "尾州不二見原";
        cube12.GetComponent<Text>().text = "東海道五拾三次";
        yield break;
    }
    IEnumerator HokusaiResult()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = false;
        cube5.GetComponent<Canvas>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().fontSize = 200;
        cube10.GetComponent<Text>().text = "終了！";
        audioSource2.clip = audioClip4;
        audioSource2.Play();
        
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().fontSize = 120;
        if (count_collect <= 1)
        {
            cube10.GetComponent<Text>().text = "あなたは" + count_collect + "問正解でした！\nガイドを見直してみよう！";
        }
        if (count_collect == 2)
        {
            cube10.GetComponent<Text>().text = "あなたは" + count_collect + "問正解でした！\nあともう少し！";
        }
        if (count_collect == 3)
        {
            GameObject cube7 = GameObject.Find("FireFlowers");
            GameObject cube8 = GameObject.Find("FireFlowers2");
            cube7.GetComponent<ParticleSystem>().Play();
            cube8.GetComponent<ParticleSystem>().Play();
            cube10.GetComponent<Text>().text = "あなたは" + count_collect + "問正解でした！\n素晴らしい！他の絵画も挑戦しよう！";
        }
        cube3.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "もう一度やる";
        cube12.GetComponent<Text>().text = "ガイドに戻る";
        yield break;
    }
    IEnumerator GohoQuizStart_1()
    {
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().text = "ゴッホのクイズスタート！";
        audioSource2.clip = audioClip1;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().text = "今回選んだ絵画の作品名を答えよ";
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = true;
        cube3.GetComponent<BoxCollider>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<BoxCollider>().enabled = true;
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "星月夜";
        cube12.GetComponent<Text>().text = "糸杉と星の見える道";
        audioSource3.Play();
        yield break;
    }
    IEnumerator GohoQuizStart_2()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = false;
        cube5.GetComponent<Canvas>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().text = "次の問題！";
        cube10.GetComponent<Text>().fontSize = 200;
        audioSource2.clip = audioClip1;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().fontSize = 120;
        cube3.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        cube10.GetComponent<Text>().text = "死の架け橋の象徴となっているところはどこか";
        audioSource3.Play();
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "雲や星空";
        cube12.GetComponent<Text>().text = "糸杉";
        yield break;
    }
    IEnumerator GohoQuizStart_3()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = false;
        cube5.GetComponent<Canvas>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().fontSize = 200;
        cube10.GetComponent<Text>().text = "最後の問題！";
        audioSource2.clip = audioClip1;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube3.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        cube10.GetComponent<Text>().fontSize = 120;
        cube10.GetComponent<Text>().text = "ゴッホの他の作品として\n当てはまるものはどれか";
        audioSource3.Play();
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "花咲くアーモンドの木の枝";
        cube12.GetComponent<Text>().text = "ルーヴル河岸通り";
        yield break;
    }
    IEnumerator GohoResult()
    {
        GameObject cube3 = GameObject.Find("QuizComand1");
        GameObject cube5 = GameObject.Find("QuizComand2");
        cube3.GetComponent<Canvas>().enabled = false;
        cube5.GetComponent<Canvas>().enabled = false;
        GameObject cube10 = GameObject.Find("Text_Q1");
        cube10.GetComponent<Text>().fontSize = 200;
        cube10.GetComponent<Text>().text = "終了！";
        audioSource2.clip = audioClip4;
        audioSource2.Play();
        yield return new WaitForSeconds(3);
        cube10.GetComponent<Text>().fontSize = 120;
        if (count_collect <= 1)
        {
            cube10.GetComponent<Text>().text = "あなたは" + count_collect + "問正解でした！\nガイドを見直してみよう！";
        }
        if (count_collect == 2)
        {
            cube10.GetComponent<Text>().text = "あなたは" + count_collect + "問正解でした！\nあともう少し！";
        }
        if (count_collect == 3)
        {
            GameObject cube7 = GameObject.Find("FireFlowers");
            GameObject cube8 = GameObject.Find("FireFlowers2");
            cube7.GetComponent<ParticleSystem>().Play();
            cube8.GetComponent<ParticleSystem>().Play();
            cube10.GetComponent<Text>().text = "あなたは" + count_collect + "問正解でした！\n素晴らしい！他の絵画も挑戦しよう！";
        }
        cube3.GetComponent<Canvas>().enabled = true;
        cube5.GetComponent<Canvas>().enabled = true;
        GameObject cube11 = GameObject.Find("Text_A1");
        GameObject cube12 = GameObject.Find("Text_A2");
        cube11.GetComponent<Text>().text = "もう一度やる";
        cube12.GetComponent<Text>().text = "ガイドに戻る";
        yield break;
    }
}
