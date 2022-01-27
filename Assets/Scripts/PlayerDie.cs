using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider Mytrigget)
    {
        if (Mytrigget.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

