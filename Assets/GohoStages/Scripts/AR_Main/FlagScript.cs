using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    
    static public bool flag = true;//このオブジェクトがオンになったかどうか

    [Header("ARモードで使う生成オブジェクト")]
    public GameObject AR_GameObject;
     GameObject AR_GameObject2;

    int count = 0;//ARStartになったら一回だけ起動

    void Start()
    {
        flag = false;
        count = 0;
    }

    void Update()
    {
        if (SystemScript.ARStart == true&& count == 0)
        {

                AR_GameObject2 = Instantiate(AR_GameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                AR_GameObject2.transform.parent = this.gameObject.transform;
                GameObject cube7 = GameObject.Find("particle_1");
                cube7.GetComponent<ParticleSystem>().Stop();
                GameObject cube8 = GameObject.Find("particle_2");
                cube8.GetComponent<ParticleSystem>().Stop();
            count = 1;

        }

    }
}
