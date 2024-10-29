using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        playerGoal = GameObject.Find("Player Goal");

        if (playerGoal == null)
        {
            Debug.LogError("Player Goal not found! Please check the name in the scene.");
        }
    }

    void Update()
    {
        if (playerGoal != null)
        {
            
            Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.name == "Enemy Goal" || other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}
