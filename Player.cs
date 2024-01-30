using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    
{   [Header("Visuals")]
    public Camera playerCamera;
    [Header("Gameplay")]
    public int initialAmmo=12;
    public int initialHealth = 100;
    
    private int health;
    public int Health { get { return health; } }
    private int ammo;
    private bool killed;
    public bool Killed { get { return killed; } }
    public int Ammo { get { return ammo; } }
    public float knockbackForce=100;
    private bool isHurt;
    public float hurtDuration = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        ammo = initialAmmo;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   if (ammo > 0 && Killed==false )
            {
                ammo--;
                Debug.Log("Fire");
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet(true);
                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;
            }
            
            
        }
    }
    //collision for ammo
    void OnTriggerEnter (Collider otherCollider)
    {
        //ammo
        if (otherCollider.GetComponent<AmmoCrate>() != null)
        {
            
            AmmoCrate ammoCrate = otherCollider.GetComponent<AmmoCrate>();
            ammo += ammoCrate.ammo;
            Destroy(ammoCrate.gameObject);
        }
        //enemy
        if (isHurt == false) {
            GameObject hazard = null;
             if (otherCollider.GetComponent<Enemy>() != null)
                {
                    {
                        Enemy enemy = otherCollider.GetComponent<Enemy>();
                        hazard = enemy.gameObject;
                        health -= enemy.damage;
                        

                    }

                }
             else if (otherCollider.GetComponent<Bullets>()!=null){
                Bullets bullets = otherCollider.GetComponent<Bullets>();
                if (bullets.ShotByPlayer == false)
                {
                    health -= bullets.damage;
                    hazard = bullets.gameObject;
                    bullets.gameObject.SetActive(false);


                }


            }
            if (hazard != null)
            {
                isHurt = true;
                Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up);
                GetComponent<Rigidbody>().AddForce(knockbackDirection * knockbackForce);
                StartCoroutine(HurtRoutine());
            }
            if (health <= 0)
            {
                if (killed == false)
                {
                    killed = true;
                    OnKill();
                }
            }
            
        }

    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtDuration);
        isHurt = false;
    }
    private void OnKill()
    {
        
    }

}
