/* NOTE

PlayerInventory holds and organizes Tara's items.

*/

using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    public ArrayList m_ItemList;


	// Use this for initialization
	void Start ()
    {
        m_ItemList = new ArrayList();
	}
	

	// Update is called once per frame
	void Update ()
    {
	
	}


    public void GetItem(GameObject item)
    {
        m_ItemList.Add(item);

        item.SetActive(false);
    }


    public void DropItem(int index)
    {

    }
}
