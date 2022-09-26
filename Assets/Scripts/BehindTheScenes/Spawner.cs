using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy() 
    {
        yield return new WaitForSeconds(Random.Range(2,15));
        Instantiate(Enemy1, transform.position, Quaternion.identity);
        StartCoroutine("SpawnEnemy");
    }
}
