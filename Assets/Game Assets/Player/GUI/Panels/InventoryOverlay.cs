using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryOverlay : MonoBehaviour {

    private GameObject m_Player;
    private PlayerInventory m_PlayerInventory;
    private Canvas m_Canvas;
    private GameObject m_ItemsPanel;

    public bool m_Visible;

    // Use this for initialization
    void Start ()
    {
        m_Player = GameObject.Find("Player");
        m_PlayerInventory = m_Player.GetComponent<PlayerInventory>();
        m_Canvas = GetComponent<Canvas>();
        m_ItemsPanel = GameObject.Find("InventoryItemsList");
        Hide();
    }
	

	// Update is called once per frame
	void Update () {

    }


    public void Show()
    {
        m_Canvas.enabled = true;
        m_Visible = true;

        Rebuild();
    }


    public void Hide()
    {
        m_Canvas.enabled = false;
        m_Visible = false;
    }


    private void Rebuild()
    {
        // Clean up the old setup
        var children = new ArrayList();
        foreach (Transform child in m_ItemsPanel.transform) children.Add(child.gameObject);
        foreach (GameObject child in children) Destroy(child);

        // Add new buttons
        RectTransform panel = m_ItemsPanel.GetComponent<RectTransform>();

        int n = m_PlayerInventory.m_ItemList.Count;
        for (int i = 0; i < n; ++i)
        {
            GameObject button= (GameObject)Instantiate(Resources.Load("GUI/ItemGUI", typeof(GameObject)));
            button.transform.SetParent(panel, false);

            // Make buttons specific to their items
            GameObject item = m_PlayerInventory.m_ItemList[0] as GameObject;

            // Set button sprite
            Sprite sprite = item.GetComponent<GameItem>().m_Icon;
            button.transform.FindChild("Image").GetComponent<Image>().sprite = sprite;
        }
    }
}
