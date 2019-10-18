using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    public int candy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            candy += 1;
        }
    }
}
