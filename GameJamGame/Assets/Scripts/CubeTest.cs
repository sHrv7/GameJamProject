using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    public GameObject cubePrefab;

    Rigidbody rb;

    public void RollDice()
    {
        Instantiate(cubePrefab, Vector3.back * 10, Quaternion.identity, transform);
        rb = transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), 0));
        rb.AddTorque(new Vector3(Random.Range(-90, 91), 0, Random.Range(-90, 91)));

    }
}
