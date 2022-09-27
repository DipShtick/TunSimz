using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{

    public Player player;

    private bool isTouching;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!player.isEquipped && isTouching)
            {
                player.isEquipped = true;
                player.pistol.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);

                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                GetComponent<BoxCollider2D>().enabled = false;
                isTouching = false;
            }
            else if (player.isEquipped && !isTouching)
            {
                player.isEquipped = false;
                player.pistol.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);

                transform.position = player.GetComponent<Transform>().position;
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (isTouching)
        {
            isTouching = false;
        }
    }
}
