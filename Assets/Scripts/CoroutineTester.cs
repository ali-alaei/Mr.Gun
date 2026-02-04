using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTester : MonoBehaviour
{

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


}
