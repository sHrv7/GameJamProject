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
            Destroy(currObj);
            currObj = other.gameObject;
        }
    }
    void Update()
    {
        if (currObj != null)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                currObj.transform.position = transform.position;

            }

            if (currObj.TryGetComponent<DiceNum>(out DiceNum dn))
                num = dn.diceNum;
        }

    }
}
