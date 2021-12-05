using System.Collections;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

public class ScreenShot : MonoBehaviour
{
    public GameObject UI4;
    private AudioSource audioSource;
    public AudioClip audioClip1;
    public GameObject TweetButtontool;

    bool Completed= false;
    float timer = 0;
    static public bool PhotoStart = false;
    string path2;
    [DllImport("__Internal")]
    private static extern void SaveToAlbum(string path);

    IEnumerator SaveToCameraroll(string path)
    {
        // ファイルが生成されるまで待つ
        while (true)
        {
            if (File.Exists(path))
                break;
            yield return null;
        }

        SaveToAlbum(path);
    }
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
    }
    void Update()
    {
        if (Completed == true)
        {
            timer +=Time.deltaTime;
            if (timer > 0.5f && timer < 3.0f)
            {
                UI4.SetActive(true);
                TweetButtontool.SetActive(true);
            }
            if (timer >= 3.0f)
            {
                UI4.SetActive(false);
                PhotoStart = false;
                Completed = false;
            }

        }

        
    }
    public void PhotoSystem()
    {
        PhotoStart = true;
        audioSource.Play();
        timer = 0;

#if UNITY_EDITOR
#else
        string filename = "test.png";
        string path = Application.persistentDataPath + "/" + filename;

        // 以前のスクリーンショットを削除する
        File.Delete(path);

        // スクリーンショットを撮影する
        ScreenCapture.CaptureScreenshot(filename);
        
        // カメラロールに保存する
        StartCoroutine(SaveToCameraroll(path));
        path2=path;
#endif
        Completed = true;

    }
    public void TweetButtonPhoto()
    {
        string text = "\n#XRGUIDEMUSEUM";
        string url = "";
        //string image = null;
        SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, text, url, path2);
    }
}