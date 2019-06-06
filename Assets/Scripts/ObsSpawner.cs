using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawner : MonoBehaviour
{
    public GameObject[] ObsPrefs;
    public GameObject StartObs;
    float obsXPos = 0;
    int obsCount = 2;
    float obsLength = 0;
    int safeZone = 160;

    public Transform PlayerTransf;
    List<GameObject> CurrentBlocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        obsXPos = StartObs.transform.position.x;
        obsLength = StartObs.GetComponent<BoxCollider2D>().bounds.size.x;

        for (int i = 0; i < obsCount; i++)
            SpawnObs();
    }

    void SpawnObs()
    {
        GameObject block = Instantiate(ObsPrefs[Random.Range(0, ObsPrefs.Length)], transform);
        obsXPos += obsLength;
        block.transform.position = new Vector2(obsXPos, 0);
        CurrentBlocks.Add(block);
    }

    void DestroyObs()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }

    void CheckForSpawn()
    {
        if(PlayerTransf.position.x - safeZone > (obsXPos - obsLength * obsCount))
        {
            SpawnObs();
            DestroyObs();
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckForSpawn();
    }
}
