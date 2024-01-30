using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    private bool gameOver = false;
    private float resetTimer = 4f;
    public GameObject enemyContainer;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI infoText;
    

    // Start is called before the first frame update
    void Start()
    {
        infoText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + player.Ammo;
        healthText.text = "Health:"+player.Health;
        enemyText.text = "Enemies:" + enemyContainer.transform.childCount;
        if (enemyContainer.transform.childCount == 0)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You win \n Well played!";
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {

                SceneManager.LoadScene("Menu");
            }
        }
        if (player.Killed == true)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You loose!Try again";
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {

                SceneManager.LoadScene("Scene1");
            }
        }
        
    }
    
}
