using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowlingTriggerRand : MonoBehaviour
{

    public GameObject textShow;

    private void OnTriggerEnter(Collider other)
    {
        int randomInt = Random.Range(0, 9);

        if (other.CompareTag("BowlingBall"))
        {
            textShow.GetComponent<TMP_Text>().text = randomInt.ToString();
            textShow.GetComponent<TMP_Text>().color = Color.red;

            Debug.Log(randomInt.ToString());
            Debug.Log("lol");
        }
    }
}
