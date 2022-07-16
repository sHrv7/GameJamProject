using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private GameObject currObj;
    //odreduje jel prvi, drugi ili treci slot
    public int num;
    public int c;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dice")
        {
            currObj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currObj = null;
    }
    void Update()
    {
        if (currObj != null)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                currObj.transform.position = transform.position;

                num = currObj.GetComponent<DiceNum>().diceNum;
            }
        }
    }
}
