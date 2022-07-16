using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    public GameObject cubePrefab;

    Rigidbody rb;
    private void Start()
    {
        InvokeRepeating("Roll", 0, 5f);
    }
    // Update is called once per frame
    void Roll()
    {
        diceRollNumber();
    }

    void diceRollNumber()
    {
        if (transform.childCount != 0)
            Destroy(this.gameObject.transform.GetChild(0).gameObject);

        Instantiate(cubePrefab, Vector3.back * 10, Quaternion.identity, transform);
        rb = transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), 0));
        rb.AddTorque(new Vector3(Random.Range(0, 91), 0, Random.Range(0, 91)));

    }
}
