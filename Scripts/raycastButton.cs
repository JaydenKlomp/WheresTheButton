using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycastButton : MonoBehaviour
{
    private Image crosshair = null;
    [SerializeField] private float maxDistance = 4f;
    [SerializeField] private float minDistance = 1f;
    public Camera playerCam;

    public Text toolTipClick;
    public Text toolTipPickUp;

    private bool hoveredButton = false;
    private bool hoveredPickUp = false;


    private void Start()
    {
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        toolTipClick = GameObject.Find("toolTipClick").GetComponent<Text>();
        toolTipPickUp = GameObject.Find("toolTipPickUp").GetComponent<Text>();
        
    }
    private void Update()
    {
        if(playerCam.enabled == true)
        {
            // Create a raycast from the center of the camera viewport
            Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            // Check if the raycast hits any object with the tag "Button"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Button"))
            {

                float distance = Vector3.Distance(ray.origin, hit.point);
                if (distance <= maxDistance)
                {
                    hoveredButton = true;
                    var clr = crosshair.color;
                    clr.a = 1f;
                    crosshair.color = clr;
                }
                else
                {
                    var clr = crosshair.color;
                    clr.a = 1f;
                    crosshair.color = clr;

                    hoveredButton = false;
                }
            }
            else
            {
                var clr = crosshair.color;
                clr.a = 1f;
                crosshair.color = clr;

                hoveredButton = false;
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("GlowGem") || hit.collider.CompareTag("BowlingBall"))
            {

                float distance = Vector3.Distance(ray.origin, hit.point);
                if (distance <= maxDistance && distance > minDistance)
                {
                    hoveredPickUp = true;
                    var clr = crosshair.color;
                    clr.a = 1f;
                    crosshair.color = clr;
                }
                else
                {
                    var clr = crosshair.color;
                    clr.a = 1f;
                    crosshair.color = clr;

                    hoveredPickUp = false;
                }
            }
            else
            {
                var clr = crosshair.color;
                clr.a = 1f;
                crosshair.color = clr;
                 
                hoveredPickUp = false;
            }

            if (hoveredButton)
            {
                toolTipClick = GameObject.Find("toolTipClick").GetComponent<Text>();
                toolTipClick.text = "Left Mouse To Click";
            }
            else
            {
                toolTipClick.text = "";

            }
            if (hoveredPickUp)
            {
                toolTipPickUp = GameObject.Find("toolTipPickUp").GetComponent<Text>();
                toolTipPickUp.text = "Left Mouse To Pick Up";
            }
            else
            {
                toolTipPickUp.text = "";
            }
        }
        
    }
}