using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{

    public Player player;

    private bool isTouching;
    

    [SerializeField]
    public Sprite objSprite;

    [SerializeField]
    public int maxAmmo = 8;

    [SerializeField]
    public int curAmmo = 8;

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
                Equip();
            }
            else if (player.isEquipped && !isTouching)
            {
                Unequip();
            }
        }
    }

    void Equip()
    {
        player.isEquipped = true;
        player.pistol.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);

        player.objectImage.sprite = objSprite;
        player.objectImage.color = new Color(1,1,1,1);
        player.holdText.text = "Holding:";
        player.ammoText.text = "Ammo: " + curAmmo + "/" + maxAmmo;

        GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        GetComponent<BoxCollider2D>().enabled = false;

        isTouching = false;
    }

    void Unequip()
    {
        player.isEquipped = false;
        player.pistol.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);

        player.objectImage.color = new Color(1,1,1,0);
        player.holdText.text = "Holding:-";
        player.ammoText.text = "Ammo: -/-";

        transform.position = player.GetComponent<Transform>().position;
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        GetComponent<BoxCollider2D>().enabled = true;
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
