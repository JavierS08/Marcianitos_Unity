using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed;

    private GameManager _gameManager;

    void Start()
    {
    _gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    _enemySpeed = Random.Range(3, 10);
    }
    
    void Update()
    {
    transform.Rotate(new Vector3(1, 1, 1));
    transform.position -= new Vector3(0, _enemySpeed * Time.deltaTime, 0);
    
    if (transform.position.y < -5)
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Player"))
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
    
        if (_gameManager != null)
            _gameManager.GameOver();
    }
    }
}
