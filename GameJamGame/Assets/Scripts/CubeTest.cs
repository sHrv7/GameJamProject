using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    public GameObject cubePrefab;

    Vector3 cubeSpawnPosition = new Vector3(-11.4899998f, 5.01000023f, 3.07705688f);

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

        rb.AddForce(new Vector3(Random.Range(-200, 201), Random.Range(-200, 201), 0));
        rb.AddTorque(new Vector3(Random.Range(0, 91), 0, Random.Range(0, 91)));

    }
}
