using UnityEngine;

public class End : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10) 
        {
            SessionManager.instance.Conclude();            
        } 
    }
}
