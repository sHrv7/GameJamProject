using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Player selectedEnemy;
    public Spell selectedCard;
    public GameObject selectedDice;
    public GameObject curr;
    private void OnTriggerEnter(Collider collision)
    {
        curr = collision.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        curr = null;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (curr != null)
            {
                if (curr.tag == "Player" && curr.gameObject != transform.parent.gameObject)
                    selectedEnemy = curr.GetComponent<Player>();
                if (curr.tag == "Card" && curr.transform.IsChildOf(transform.parent.GetChild(0)))
                    selectedCard = curr.GetComponent<Spell>();
                if (curr.tag == "Dice")
                    selectedDice = curr;
            }

            if (selectedDice != null)
            {
                selectedDice.transform.position = transform.position + Vector3.back;
                float xRot = selectedDice.transform.eulerAngles.x;
                float yRot = selectedDice.transform.eulerAngles.y;
                float zRot = selectedDice.transform.eulerAngles.z;
                if (xRot < 45)
                    xRot = 0;
                else
                    xRot = 90;
                if (yRot < 45)
                    yRot = 0;
                else
                    yRot = 90;
                if (zRot < 45)
                    zRot = 0;
                else
                    zRot = 90;
                //izravnata kocka
                selectedDice.transform.eulerAngles = new Vector3(xRot, yRot, zRot);

            }
        }
        else
        {
            selectedDice = null;
            selectedCard = null;
        }
        MovePos();
    }
    public void MovePos()
    {
        transform.GetComponent<Rigidbody>().MovePosition((Vector3)(Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
