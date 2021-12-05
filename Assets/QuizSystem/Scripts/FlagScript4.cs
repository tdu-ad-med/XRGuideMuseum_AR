using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript4 : MonoBehaviour
{
    [Header("ARモードで使う生成オブジェクト")]
    public GameObject AR_GameObject_4;
    GameObject AR_GameObject4;
    int count = 0;//ARStartになったら一回だけ起動
    static public bool ARQuizOn = false;
    // Start is called before the first frame update
    void Start()
    {
        ARQuizOn = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            AR_GameObject4 = Instantiate(AR_GameObject_4, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            AR_GameObject4.transform.parent = this.gameObject.transform;
            ARQuizOn = true;
            count = 1;

        }
    }
}
