using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KeyCalculator : MonoBehaviour
{
    public BlockFilter blockFilterRed;
    public BlockFilter blockFilterGreen;
    public BlockFilter blockFilterBlue;

    public Animator animatorDoorOpening;

    public GameObject mainCam;
    public GameObject secondCam;

    private bool locked = true;

    public void CheckBlockFilter()
    {

        if (blockFilterRed.KeyEntered && blockFilterGreen.KeyEntered && blockFilterBlue.KeyEntered)
        {
            locked = false;
            animatorDoorOpening.SetBool("PuzzleSolved", true);

            mainCam.GetComponent<Camera>().enabled = false;
            secondCam.GetComponent<Camera>().enabled = true;
            UnityEngine.Debug.Log("Door Unlocked");

            StartCoroutine(PlayCutscene());
            

        }
        else if(!locked)
        {
            animatorDoorOpening.SetBool("PuzzleSolved", false);

            mainCam.GetComponent<Camera>().enabled = false;
            secondCam.GetComponent<Camera>().enabled = true;

            StartCoroutine(PlayCutscene());
        }
    }

    private IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(2f);

        mainCam.GetComponent<Camera>().enabled = true;
        secondCam.GetComponent<Camera>().enabled = false;
    }
}