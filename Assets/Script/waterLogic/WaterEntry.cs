using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEntry : MonoBehaviour
{
    public bool EntryInWaterUp;
    public bool EntryInWaterDown;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.GetComponent<PlayerMove>().inWaterFloor = false;  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position.y > transform.position.y)
        {
            collision.GetComponent<PlayerMove>().inWaterFloor = EntryInWaterUp;
        }
        else if(collision.gameObject.transform.position.y < transform.position.y)
        {
            collision.GetComponent<PlayerMove>().inWaterFloor = EntryInWaterDown;
        }
    }
}
