using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerScale : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Audio _audio;
    
    [SerializeField] private float timeRemaining = 10f;
    private Vector3 minusScale = new Vector3(1, 1, 1);

    private Vector3 scaleForWin = new Vector3(0, 0, 0);
    private Vector3 scaleForBoost = new Vector3(10,10,10);
    

    [SerializeField] private GameObject boost;
    [SerializeField] private GameObject text, text2;
    [SerializeField] public int lives = 3;
    public bool hasSpawned, playSmallAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            playSmallAudio = false;
        }
        else if (timeRemaining <= 0)
        {
            transform.localScale -= minusScale;
            playSmallAudio = true;
            timeRemaining = 10f;
        }
        

        if (transform.localScale == scaleForWin)
        {
            SceneManager.LoadScene(4);
        }

        if (transform.localScale == scaleForBoost && !hasSpawned)
        {
            GameObject forBoost = Instantiate(boost, new Vector3(Random.Range(-85,85), Random.Range(-46,46), 0),
                transform.rotation) as GameObject;
            hasSpawned = true;
        }

        if (transform.localScale == new Vector3(15, 15, 15))
        {
            SceneManager.LoadScene(3);
        }
        text.GetComponent<Text>().text = timeRemaining.ToString("F2");
        text2.GetComponent<Text>().text = lives.ToString() + " Life";
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timeRemaining = 10f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            lives--;
            if (lives <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
