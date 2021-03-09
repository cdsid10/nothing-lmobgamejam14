using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    private PlayerMovement playerMovement;
    
    [SerializeField] private GameObject[] squares;
    [SerializeField] private GameObject placeholder;

    [SerializeField] private Transform player;

    private bool hasStarted;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnSquare());
        Invoke(nameof(StartSpawn), 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        
    }

    IEnumerator SpawnSquare()
    {
        while (true)
        {
            GameObject pHolder = Instantiate(placeholder, new Vector3(transform.position.x + Random.Range(-3, 3),
                transform.position.y + Random.Range(-3, 3), transform.position.z), transform.rotation) as GameObject;
           yield return new WaitForSeconds(0.5f); 
            Instantiate(squares[Random.Range(0, squares.Length)], pHolder.transform.position, Quaternion.Euler(0,0,Random.Range(0, 360)));
            yield return new WaitForSeconds(Random.Range(0.15f, 0.35f));
        }
        
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnSquare());
    }
  
}

/*Instantiate(squares[Random.Range(0, squares.Length)], new Vector3(transform.position.x + Random.Range(-10, 10),
    transform.position.y + Random.Range(-10, 10),
    transform.position.z), transform.rotation); */