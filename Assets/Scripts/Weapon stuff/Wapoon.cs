using System.Collections;
using UnityEngine;

public class Wapoon : MonoBehaviour
{
    public GameObject Bullet;
    private Camera cum;
    // Start is called before the first frame update
    void Start()
    {
        gm.rangePistol = 100f;
        gm.fireratePistol = 5f;
        isShooting = false;
        cum = Camera.main;
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

    public GameManager gm;
    Ray2D shit;
    RaycastHit2D poop;
    public IEnumerator Shoot()
    {
        shit = new Ray2D(gameObject.transform.position, Input.mousePosition);
        Instantiate(Bullet, shit.origin, Quaternion.identity);

        yield return new WaitForSeconds(gm.fireratePistol);
    }

}
