using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting" + Time.time);
        StartCoroutine((PrintfAfter(2.0f)));
    }

    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("Done " + Time.time);
    }
}
