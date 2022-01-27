using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChunksPlacer : MonoBehaviour
{
    public int Score = 0;
    public GameObject TextScore;
    public float MoveSpeed = 50f;
    public Transform Player;
    public Chunk ChunkPrefab;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    int l = 0;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Chunk newChunk = Instantiate(ChunkPrefab);
            newChunk.transform.localPosition = new Vector3(l, 0, 0);
            l += 3;
            spawnedChunks.Add(newChunk);
        }
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            Score++;
            TextScore.GetComponent<Text>().text = "Score: " + Score.ToString();
            MoveChunk();
            if (Player.position.x > spawnedChunks[spawnedChunks.Count - 1].End.position.x - 20 && spawnedChunks[spawnedChunks.Count - 1].transform.position.y == 0f && spawnedChunks[spawnedChunks.Count - 1].transform.position.z == 0f)
            {
                SpawnChunk();
            }
            if (spawnedChunks[spawnedChunks.Count - 1].transform.position.y != 0)
            {
                spawnedChunks[spawnedChunks.Count - 1].transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
                if (spawnedChunks[spawnedChunks.Count - 1].transform.position.y < 0.1f)
                {
                    spawnedChunks[spawnedChunks.Count - 1].transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x, 0, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.z);
                }
            }
            if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z > 0)
            {
                spawnedChunks[spawnedChunks.Count - 1].transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
                if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z < 0.1f)
                {
                    spawnedChunks[spawnedChunks.Count - 1].transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.y, 0);
                }
            }
            if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z < 0)
            {
                spawnedChunks[spawnedChunks.Count - 1].transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
                if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z > 0.1f)
                {
                    spawnedChunks[spawnedChunks.Count - 1].transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.y, 0);
                }
            }
            if (spawnedChunks.Count >= 9)
            {
                spawnedChunks[0].transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
                if (spawnedChunks[0].transform.position.y < -4)
                {
                    Destroy(spawnedChunks[0].gameObject);
                    spawnedChunks.RemoveAt(0);
                }
            }
        }
        else
        {
            if (spawnedChunks[spawnedChunks.Count - 1].transform.position.y != 0)
            {
                spawnedChunks[spawnedChunks.Count - 1].transform.Translate(Vector3.down  * Time.deltaTime);
                if (spawnedChunks[spawnedChunks.Count - 1].transform.position.y < 0.1f)
                {
                    spawnedChunks[spawnedChunks.Count - 1].transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x, 0, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.z);
                }
            }
            if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z > 0)
            {
                spawnedChunks[spawnedChunks.Count - 1].transform.Translate(Vector3.back  * Time.deltaTime);
                if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z < 0.1f)
                {
                    spawnedChunks[spawnedChunks.Count - 1].transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.y, 0);
                }
            }
            if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z < 0)
            {
                spawnedChunks[spawnedChunks.Count - 1].transform.Translate(Vector3.forward  * Time.deltaTime);
                if (spawnedChunks[spawnedChunks.Count - 1].transform.position.z > 0.1f)
                {
                    spawnedChunks[spawnedChunks.Count - 1].transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.y, 0);
                }
            }
            if (spawnedChunks.Count >= 9)
            {
                spawnedChunks[0].transform.Translate(Vector3.down  * Time.deltaTime);
                if (spawnedChunks[0].transform.position.y < -4)
                {
                    Destroy(spawnedChunks[0].gameObject);
                    spawnedChunks.RemoveAt(0);
                }
            }
        }
    }

    private void SpawnChunk()
    {
        int side;
        Chunk newChunk = Instantiate(ChunkPrefab);


        side = Random.Range(0, 3);
        if (side == 0) //сверху
        {
            newChunk.transform.position *= 3;
            newChunk.transform.position = (spawnedChunks[spawnedChunks.Count - 1].End.position) + (newChunk.Spawn.localPosition);
            newChunk.transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.x+3, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.y + 3, spawnedChunks[spawnedChunks.Count - 1].transform.localPosition.z);
            spawnedChunks.Add(newChunk);
        }
        if (side == 1) // справа
        {
            newChunk.transform.position *= 3;
            newChunk.transform.position = (spawnedChunks[spawnedChunks.Count - 1].End.position) + (newChunk.Spawn.localPosition);
            newChunk.transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.position.x+3, spawnedChunks[spawnedChunks.Count - 1].transform.position.y , spawnedChunks[spawnedChunks.Count - 1].transform.position.z-3);
            spawnedChunks.Add(newChunk);
        }
        if (side == 2) // слева
        {
            newChunk.transform.position *= 3;
            newChunk.transform.position = (spawnedChunks[spawnedChunks.Count - 1].End.position) + (newChunk.Spawn.localPosition);
            newChunk.transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 1].transform.position.x+3, spawnedChunks[spawnedChunks.Count - 1].transform.position.y , spawnedChunks[spawnedChunks.Count - 1].transform.position.z+3);
            spawnedChunks.Add(newChunk);
        }

    }

    public  void MoveChunk()
    {
        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            if (spawnedChunks[i].transform.position.x > Player.position.x - 4)
            {
                spawnedChunks[i].transform.position += new Vector3(-0.1f, 0, 0);
            }
        }
    }



}
