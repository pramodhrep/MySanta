using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{
    public int Life = 3;
    public Animator animator;
    public bool toBlast = false;

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
        if(otherObject.gameObject.tag == "Player")
        {
            

            if (Life > 0)
            {
                Life = Life - 1;
            

                if(this.gameObject.tag == "Bomb" || this.gameObject.tag == "Mine")
                {
                    toBlast = true;
                }
                else
                {
                    Destroy(gameObject);
                    toBlast = false;
                }
            
                animator.SetBool("toBlast", toBlast);
             }

            else
            {
                Debug.Log("Game Over...  No Lifes Left");
            }
        }
    }
}
