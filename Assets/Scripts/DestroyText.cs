using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextBeDead());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextBeDead()
    {
        Destroy(gameObject, 3f);
        yield return new WaitForSeconds(1);
    }
}
