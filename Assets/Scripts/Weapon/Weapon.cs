using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameManager gameManager;
    private Ray2D ray;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.rangePistol = 100f;
        gameManager.fireratePistol = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shoot()
    {
        ray = new Ray2D(gameObject.transform.position, Input.mousePosition);
        Instantiate(bullet, ray.origin, Quaternion.identity);

        yield return new WaitForSeconds(gameManager.fireratePistol);
    }

}
