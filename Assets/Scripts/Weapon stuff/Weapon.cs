using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    public InputAction playerAttack;

    public GameManager gameManager;

    private Ray2D ray;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.rangePistol = 100f;
        gameManager.fireratePistol = 5f;
        isShooting = false;
    }

    [SerializeField] private bool isShooting;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!isShooting)
            {
                StartCoroutine(Shoot());
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopCoroutine(Shoot());
            isShooting = false;
        }   
    }

    public IEnumerator Shoot()
    {
        ray = new Ray2D(gameObject.transform.position, Input.mousePosition);
        Instantiate(bullet, ray.origin, Quaternion.identity);

        yield return new WaitForSeconds(gameManager.fireratePistol);
    }

}
