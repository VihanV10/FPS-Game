using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    private bool killed = false;
    public int damage = 5;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        
        if (otherCollider.GetComponent<Bullets>() != null)
        {
            Debug.Log("Dead");
            Bullets bullets = otherCollider.GetComponent<Bullets>();
            if (bullets.ShotByPlayer == true)
            {
                health -= bullets.damage;
                bullets.gameObject.SetActive(false);
                if (health <= 0)
                { 
                        
                      
                        killed = true;
                        Destroy(gameObject);

                
                    
                   
                }
            }

        }
    }
    protected virtual void OnKill()
    {

    }

}
