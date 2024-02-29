using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BowlingTrigger : MonoBehaviour
{
    public GameObject textShow;
    [HideInInspector] public GameObject pincode;

    int pin1 = 0;
    int pin2 = 0;
    int pin3 = 0;
    int pin4 = 0;

    int Bowled = 0;

    private void Start()
    {
        pincode = GameObject.Find("pincode");
        pin1 = pincode.GetComponent<PincodeBowling>().pin1;
        pin2 = pincode.GetComponent <PincodeBowling>().pin2;
        pin3 = pincode.GetComponent<PincodeBowling>().pin3;
        pin4 = pincode.GetComponent<PincodeBowling>().pin4;

        Bowled = pincode.GetComponent<PincodeBowling>().Bowled;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (pincode.GetComponent<PincodeBowling>().Bowled > 0 && pincode.GetComponent<PincodeBowling>().Bowled < 5)
        {
            Bowled = pincode.GetComponent<PincodeBowling>().Bowled;
        }

        if (other.CompareTag("BowlingBall"))
        {
            Bowled++;
            pincode.GetComponent<PincodeBowling>().Bowled = Bowled;

            if (Bowled > 4)
            {
                Bowled = 5;
                pincode.GetComponent<PincodeBowling>().Bowled = Bowled;
            }

            Debug.Log("entered");
            Debug.Log(pincode.GetComponent<PincodeBowling>().Bowled);

            switch (Bowled)
            {
                case 1:
                    textShow.GetComponent<TMP_Text>().text = pin1.ToString();
                    textShow.GetComponent<TMP_Text>().color = Color.green;
                    Debug.Log(pincode.GetComponent<PincodeBowling>().Bowled);
                break;
                case 2:
                    textShow.GetComponent<TMP_Text>().text = pin2.ToString();
                    textShow.GetComponent<TMP_Text>().color = Color.green;
                    Debug.Log(pincode.GetComponent<PincodeBowling>().Bowled);
                break;
                case 3:
                    textShow.GetComponent<TMP_Text>().text = pin3.ToString();
                    textShow.GetComponent<TMP_Text>().color = Color.green;
                    Debug.Log(pincode.GetComponent<PincodeBowling>().Bowled);
                break;
                case 4:
                    textShow.GetComponent<TMP_Text>().text = pin4.ToString();
                    textShow.GetComponent<TMP_Text>().color = Color.green;
                    Debug.Log(pincode.GetComponent<PincodeBowling>().Bowled);
                break;
            }
            
        }
    }
}
