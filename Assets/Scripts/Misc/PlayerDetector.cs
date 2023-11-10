using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] bool reversed;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!reversed)
            {
                transform.parent.GetComponent<AIMovement>().setTarget();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (reversed)
            {
                transform.parent.GetComponent<AIMovement>().DisableMovement();
            }
        }
    }
}
