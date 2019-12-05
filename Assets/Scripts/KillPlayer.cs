using UnityEngine;

// If this behavior is connected to an object, a player dies upon
// collision with it.
public class KillPlayer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.Die();
        }
    }

}
