using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsCreate : MonoBehaviour
{
    public Transform Player;
    public GameObject Trap;
    public List<GameObject> TrapsSpawn = new List<GameObject>();
    public float MoveSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            if (TrapsSpawn.Count == 0)
            {
                SpawnTrap();
            }
            Move();
            if (TrapsSpawn[0].transform.position.z < 0)
            {
                TrapsSpawn[0].transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
                if (TrapsSpawn[0].transform.position.z > 0.1f)
                {
                    TrapsSpawn[0].transform.position = new Vector3(TrapsSpawn[0].transform.position.x, TrapsSpawn[0].transform.position.y, 0);
                }
            }
            TrapsSpawn[0].transform.position = new Vector3(TrapsSpawn[0].transform.position.x, 7 + Mathf.Sin(Time.fixedTime * 3) * 5, TrapsSpawn[0].transform.position.z);
        }
        else
        {
            if (TrapsSpawn[0].transform.position.z < 0)
            {
                TrapsSpawn[0].transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
                if (TrapsSpawn[0].transform.position.z > 0.1f)
                {
                    TrapsSpawn[0].transform.position = new Vector3(TrapsSpawn[0].transform.position.x, TrapsSpawn[0].transform.position.y, 0);
                }
            }
            TrapsSpawn[0].transform.position = new Vector3(TrapsSpawn[0].transform.position.x, 7 + Mathf.Sin(Time.fixedTime * 3) * 5, TrapsSpawn[0].transform.position.z);
        }
    }

    private void SpawnTrap()
    {
        GameObject spawn = Instantiate(Trap);

        spawn.transform.position = new Vector3(Player.position.x+15,Player.position.y,Player.position.z-10);
        TrapsSpawn.Add(spawn);
    }

    private void Move()
    {
        if (TrapsSpawn[0].transform.position.x > Player.position.x - 6)
        {
            TrapsSpawn[0].transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (TrapsSpawn[0].transform.position.x < -3)
        {
           Destroy(TrapsSpawn[0].gameObject);
           TrapsSpawn.RemoveAt(0);
        }
        if (TrapsSpawn.Count > 2)
        {
            Destroy(TrapsSpawn[0].gameObject);
            TrapsSpawn.RemoveAt(0);
        }
    }
 
}
