using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Player selectedEnemy;
    public Spell selectedCard;
    public GameObject selectedDice;
    public GameObject curr;
    public GameObject enemyTarget;
    private void OnTriggerEnter(Collider collision)
    {
        curr = collision.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (curr != null)
        {
            if (curr.TryGetComponent<Slot>(out Slot s))
            {
                s.showLegend = false;
            }
        }
        curr = null;
    }
    private void Update()
    {
        if (curr != null)
        {
            if (curr.tag == "Slot")
            {
                curr.GetComponent<Slot>().showLegend = true;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (curr != null)
            {
                if (curr.tag == "Player" && curr.gameObject != transform.parent.gameObject)
                {
                    selectedEnemy = curr.GetComponent<Player>();
                    selectedDice = null;
                }
                if (curr.tag == "Dice")
                {
                    selectedDice = curr;
                    selectedEnemy = null;
                }
            }

            if (selectedDice != null)
            {
                selectedDice.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                selectedDice.transform.position = transform.position + Vector3.back;
            }
        }
        else
        {
            selectedDice = null;
        }

        MovePos();
    }
    public void MovePos()
    {
        transform.GetComponent<Rigidbody>().MovePosition((Vector3)(Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
