using UnityEngine;
using System.Collections;

public class TeamFormation : MonoBehaviour
{

    public GameObject FormationList;
    public GameObject PlayerPrefab;
    Vector3[] Spawns = new[]
        {new Vector3(-30,0,0),
         new Vector3(-20,0,0),
         new Vector3(-15,0,0),
         new Vector3(-5,0,0),
         new Vector3(0,0,-5),
         new Vector3(0,0,0),
         new Vector3(0,0,-10),
         new Vector3(5,0,0),
         new Vector3(15,0,0),
         new Vector3(20,0,0),
         new Vector3(30,0,0),
        };


    void Start()
    {
        foreach (Vector3 Spawn in Spawns)
        {
            GameObject newPlayer;
            newPlayer = (GameObject)Instantiate(PlayerPrefab, Spawn + transform.position, Quaternion.identity);
            newPlayer.transform.parent = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
