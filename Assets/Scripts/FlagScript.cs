using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    static public bool flag = true;

    public GameObject Test1;
    GameObject Test1_1;

 

    //public GameObject Test2;
    //GameObject Test2_2;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (SystemScript.ARStart == true)
        {
            if (count == 0)
            {
                Test1_1 = Instantiate(Test1, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Test1_1.transform.parent = this.gameObject.transform;
                count = 1;
            }
        }

    }

   /* public void TextARStart()
    {
        LogSystemScript.TextLog += 1;
        Test2_2 =Instantiate(Test2, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
        Test2_2.transform.parent = this.gameObject.transform;
    }*/
}
