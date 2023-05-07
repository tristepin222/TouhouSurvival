using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] public Item item;
    [SerializeField] float speed = 1;
    private bool canMoveTowards;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = new Quaternion(0, 0, Random.rotation.z, Random.rotation.w); 
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveTowards)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, step);
        }
    }

    public void MoveTowards()
    {
        canMoveTowards = true;
    }
}
