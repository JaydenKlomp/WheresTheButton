using UnityEngine;

public class SpawnScriptLvlOne : MonoBehaviour
{
    public GameObject teleportDestination; // The destination where you want to teleport the player
    public GameObject player;

    private void Start()
    {
        // Find the player GameObject using the tag
        // where ‘yourplayerobject’ - your player GO of type GameObject

        if (player != null)
        {
            // Teleport the player to the destination
            player.transform.position = teleportDestination.transform.position;
        }
        else
        {
            Debug.LogWarning("Player not found!");
        }

        

    }
}
