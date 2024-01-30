using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance { get { return instance;  } }
    public GameObject bulletPrefab;
    public int BulletAmount = 20;
    private List<GameObject> bullets;
    // Start is called before the first frame update
    void Awake ()
    {
        instance = this;
        bullets = new List<GameObject>(BulletAmount);
        for (int i=0; i<BulletAmount;i++)
        {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            bullets.Add(prefabInstance);
        }
        
    }
    public GameObject GetBullet (bool shotByPlayer)
    {
        Debug.Log("Hello");
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullets>().ShotByPlayer = shotByPlayer;
                return bullet;
            }
        }
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        prefabInstance.GetComponent<Bullets>().ShotByPlayer = shotByPlayer;

        bullets.Add(prefabInstance);
        return prefabInstance;

    }

}
