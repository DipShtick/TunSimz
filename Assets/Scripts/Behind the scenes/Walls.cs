using UnityEngine;

public class Walls : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider) 
    {
        Destroy(collider.gameObject);
    }

}
