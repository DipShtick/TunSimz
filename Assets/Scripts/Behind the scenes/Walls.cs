using UnityEngine;

public class Walls : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D col) 
    {
        Destroy(col.gameObject);
    }

}
