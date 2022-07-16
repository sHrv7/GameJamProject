using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;

    Vector3 cubeSpawnPosition = new Vector3(-11.4899998f, 5.01000023f, 3.07705688f);

    Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            diceRollNumber(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            diceRollNumber(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            diceRollNumber(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            diceRollNumber(4);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            diceRollNumber(5);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            diceRollNumber(6);
    }

    void diceRollNumber(int num)
    {
        if (transform.childCount != 0)
            Destroy(this.gameObject.transform.GetChild(0).gameObject);

        Instantiate(cubePrefab, cubeSpawnPosition, Quaternion.identity, transform);
        rb = this.gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Rigidbody>();

        switch (num)
        {
            case 1:
                rb.AddForce(new Vector3(250, 0, 0));
                rb.AddTorque(new Vector3(10, 0, 10));
                break;

            case 2:
                rb.AddForce(new Vector3(400, 0, 10));
                rb.AddTorque(new Vector3(20, 40, 10));
                break;

            case 3:
                rb.AddForce(new Vector3(340, 0, 10));
                rb.AddTorque(new Vector3(70, 40, 90));
                break;

            case 4:
                rb.AddForce(new Vector3(400, 0, 0));
                rb.AddTorque(new Vector3(10, 10, 10));
                break;

            case 5:
                rb.AddForce(new Vector3(250, 0, 0));
                rb.AddTorque(new Vector3(20, 35, 10));
                break;

            case 6:
                rb.AddForce(new Vector3(340, 0, 0));
                rb.AddTorque(new Vector3(20, 40, 90));
                break;

            default:
                break;
        }
    }
}
