using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Weapon value;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.Find("pis_bullet");
    }

    public Player user;

    private void shoot()
    {
        if (user)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void lookatMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (mousePos - new Vector2(transform.position.x - transform.position.y));
    }
}
