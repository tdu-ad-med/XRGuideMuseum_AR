using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript_2 : MonoBehaviour
{
    static public bool flag_2 = true;//ARモード判定用、ONになったらflagはfalseになる

    [Header("ARモードで使う生成オブジェクト")]
    public GameObject AR_GameObject;
    GameObject AR_GameObject2;

    int count = 0;//ARStartになったら一回だけ起動
    // Start is called before the first frame update
    void Start()
    {
        flag_2 = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemScript.ARStart_2 == true)
        {
            if (count == 0)
            {
                AR_GameObject2 = Instantiate(AR_GameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                AR_GameObject2.transform.parent = this.gameObject.transform;
                GameObject cube7 = GameObject.Find("WaveAnimation");
                cube7.GetComponent<ParticleSystem>().Stop();
                GameObject cube8 = GameObject.Find("WaveAnimation2");
                cube8.GetComponent<ParticleSystem>().Stop();
                GameObject cube9 = GameObject.Find("Splash");
                cube9.GetComponent<ParticleSystem>().Stop();
                GameObject cube10 = GameObject.Find("Splash2");
                cube10.GetComponent<ParticleSystem>().Stop();
                count = 1;
            }
        }
    }
}
