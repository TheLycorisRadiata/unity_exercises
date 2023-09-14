using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Contains("Steak"))
        {
            --PlayerStats.instance.lives;
            PlayerStats.instance.DisplayLives();
        }   
    }
}
