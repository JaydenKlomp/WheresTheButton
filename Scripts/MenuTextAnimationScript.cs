using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuTextAnimationScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator txtAnim;
    public Animator knopjeAnim;

    GameObject menuText;
    GameObject menuKnopje;
    GameObject animHolderTxt;
    GameObject animHolderKnopje;

    GameObject textTag;
    GameObject knopTag;

    public void Start()
    {
        //textTag = GameObject.FindWithTag("menuButton");
        //knopTag = GameObject.FindWithTag("uiRedButton");
        //
        //Destroy(textTag.GetComponent<Animator>());
        //Destroy(knopTag.GetComponent<Animator>());
        //
        //animHolderTxt = GameObject.Find("animHolderTxt");
        //animHolderKnopje = GameObject.Find("animHolderKnopje");

        txtAnim = GetComponent<Animator>();
        knopjeAnim = txtAnim.transform.GetChild(0).GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //menuText = pointerEventData.pointerEnter;
        //menuKnopje = menuText.transform.GetChild(0).gameObject;
        //
        //Debug.Log(menuText.name);
        //
        //if (animHolderTxt != null && animHolderKnopje != null)
        //{
        //    Debug.Log(animHolderTxt + "yuh");
        //
        //    menuText.AddComponent<Animator>();
        //    menuKnopje.AddComponent<Animator>();
        //
        //    menuText.GetComponent<Animator>().runtimeAnimatorController = animHolderTxt.GetComponent<Animator>().runtimeAnimatorController;
        //    menuKnopje.GetComponent<Animator>().runtimeAnimatorController = animHolderKnopje.GetComponent<Animator>().runtimeAnimatorController;
        //
        //    //menuText.GetComponent<Animator>().Play("menuTextMove");
        //    //menuKnopje.GetComponent<Animator>().Play("knopjeRol");
        //}
        //else
        //{
        //    Debug.Log(animHolderTxt + "nah");
        //}
        //
        //txtAnim = menuText.GetComponent<Animator>();
        //knopjeAnim = txtAnim.transform.GetChild(0).GetComponent<Animator>();
        //
        txtAnim.SetBool("mouseEnter", true);
        knopjeAnim.SetBool("mouseEnter", true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //menuText = pointerEventData.pointerEnter;
        //Debug.Log(menuText.name);
        //
        //txtAnim = menuText.GetComponent<Animator>();
        //knopjeAnim = txtAnim.transform.GetChild(0).GetComponent<Animator>();

        txtAnim.SetBool("mouseEnter", false);
        knopjeAnim.SetBool("mouseEnter", false);
    }
}
