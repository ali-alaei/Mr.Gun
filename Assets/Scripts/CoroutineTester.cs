using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine(10));
    }

    IEnumerator MyCoroutine(int count)
    {

        int i = 0;

        while (i < count)
        {
            i++;
            Debug.Log(i);
            yield return new WaitForSeconds(2);
        }

        Debug.Log("coroutine is done");

    }

    //private void Update()
    //{
    //    int i = 0;
    //    int count = 11;

    //    while (i < count)
    //    {
    //        i++;
    //        Debug.Log(i);
    //        //yield return new WaitForSeconds(2);
    //    }

    //    Debug.Log("update is done");

    //}
}
