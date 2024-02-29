using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWater : MonoBehaviour
{
    public GameObject player;
    public string playerName;
    public Vector3 deadPosition;
    public Vector3 deadPositionKeyRed;
    public Vector3 deadPositionKeyGreen;
    public Vector3 deadPositionKeyBlue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            player.transform.position = deadPosition;
        }

        if (other.gameObject.name == "RedKey")
        {
            other.transform.position = deadPositionKeyRed;
        }

        if(other.gameObject.name == "GreenKey")
        {
            other.transform.position = deadPositionKeyGreen;
        }

        if(other.gameObject.name == "BlueKey")
        {
            other.transform.position = deadPositionKeyBlue;
        }

    }

}
