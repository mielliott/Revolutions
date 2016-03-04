/* NOTE

GameItem is a component that can be added to objects in the game world to make
them able to be picked up or otherwise manipulated as an "item."

*/

using UnityEngine;
using System.Collections;

public class GameItem : MonoBehaviour
{
    [SerializeField] public string m_Name = "Lasagna";
    [SerializeField] public double m_Weight = 0.0;
    [SerializeField] public Sprite m_Icon;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
