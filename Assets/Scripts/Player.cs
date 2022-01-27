using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform transformPlayer;
    public bool StopGame = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //transformPlayer.position += new Vector3(0.1f, 0, 0);
            transformPlayer.Rotate(0, 0, 45);
            StopGame = false;
        }
        else
        {
            //transformPlayer.position += new Vector3(0, 0, 0);
            StopGame = true;
        }
    }


}
