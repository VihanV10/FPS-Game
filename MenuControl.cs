using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void OnPlay()
    {
        Debug.Log("Scene1");
        SceneManager.LoadScene("Scene1");
    }
}
