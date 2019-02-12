using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bear")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("DeathScene");
        }
    }


}
