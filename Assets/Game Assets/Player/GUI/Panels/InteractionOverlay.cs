using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InteractionOverlay : MonoBehaviour {
    private Text m_OverlayText;
    private string m_ActionText = "Pick up ";
    private string m_ObjectText = "lasagna";
    private bool m_Visible = false;
    private bool m_Enabled = false;

    private GameObject m_FocusObject;
    private PlayerInventory m_PlayerInventory;

    // Use this for initialization
    void Start () {
        m_OverlayText = GetComponent<Text>();
        m_PlayerInventory = GameObject.FindObjectOfType<PlayerInventory>();

        HideText();
	}
	
	// Update is called once per frame
	void Update () {

        if (!m_Enabled)
            return;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); FOR REFERENCE :)
        RaycastHit hit;

        int layerMask = Layers.InteractiveObjects;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, layerMask))
        {
            GameItem io = hit.collider.GetComponent<GameItem>();

            // If an interactive object was found, determine display the interaction text
            if (io != null)
            {
                m_FocusObject = hit.collider.gameObject;
                m_ObjectText = io.m_Name;
                ShowText();
                return;
            }
        }

        m_FocusObject = null;
 
        // Hide interaction text if nothing was found
        HideText();
    }

    //  Make the text visible.
    void ShowText()
    {
        if (m_FocusObject != null)
        {
            m_Visible = true;
            m_OverlayText.text = string.Concat(m_ActionText, m_ObjectText);
        }
    }

    //  HideText hides the overlay.
    void HideText()
    {
        m_Visible = false;
        m_OverlayText.text = "";
    }

    //  TryInteraction attempts to interact with focusObject.
    public bool TryInteraction()
    {
        if (m_FocusObject == null)
            return false;
        else
        {
            // If it's an item, pick it up
            if (m_FocusObject.GetComponent<GameItem>() != null)
                m_PlayerInventory.GetItem(m_FocusObject);

            return true;
        }
    }

    public void Enable()
    {
        m_Enabled = true;
    }

    public void Disable()
    {
        m_Enabled = false;
        HideText();
    }
}
