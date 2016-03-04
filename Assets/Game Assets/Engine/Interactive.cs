/* NOTE

Interactive is a component that can be added to objects in the game world to
make them do stuff when the player presses the interaction button on them. The
script to run for the interaction should be determined in the prefab options.

*/

using UnityEngine;
using System;

public class Interactive : MonoBehaviour
{
    [SerializeField] public string m_InteractionText = "Do me";
    [SerializeField] private Component m_InteractionScript = null;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
