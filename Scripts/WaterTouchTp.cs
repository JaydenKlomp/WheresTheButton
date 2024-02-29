using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterTouchTp : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        // Find the player GameObject using the tag
        GameObject player = GameObject.FindWithTag("playerObj");

        if (other.CompareTag("Water"))
        {
            // Teleport the player to the destination
            TeleportToNearestWaterTP();
        }
    }

    private void TeleportToNearestWaterTP()
    {
        GameObject[] waterTeleportPoints = GameObject.FindGameObjectsWithTag("waterTP");
        float shortestDistance = Mathf.Infinity;
        Transform nearestTP = null;

        foreach (GameObject tp in waterTeleportPoints)
        {
            float distance = Vector3.Distance(transform.position, tp.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTP = tp.transform;
            }
        }

        if (nearestTP != null)
        {
            transform.position = nearestTP.position;
        }
    }

}
