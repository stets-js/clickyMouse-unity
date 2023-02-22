using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;
    public ParticleSystem objectPartical;
    private float minForce = 12;
    private float maxForce = 16;
    private float torgue = 10;
    private float spawnXPos = 4;
    private float spawnYPos = -2;
    public int destroyPoints;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb.AddForce(Randomforce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorgue(), RandomTorgue(), RandomTorgue(), ForceMode.Impulse);

        transform.position = SpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(destroyPoints);
            Instantiate(objectPartical, transform.position, objectPartical.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.livesNum > 0)
        {
            gameManager.UpdateLives(1);

        }
        if (gameManager.livesNum == 0)
        {
            gameManager.GameOver();
        }
    }

    Vector3 Randomforce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float RandomTorgue()
    {
      return  Random.Range(-torgue, torgue);
    }

    Vector3 SpawnPosition()
    {
        return new Vector3(Random.Range(-spawnXPos, spawnXPos), spawnYPos);
    }
}
