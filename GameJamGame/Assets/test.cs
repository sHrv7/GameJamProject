using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int i = 0;
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.color = new Color(Random.value, Random.value, Random.value);
        i++;
        transform.Rotate(new Vector3(i, i));

        //jel radi?

        transform.Translate(1, 1, 1);
    }
}
