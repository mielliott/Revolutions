/* NOTE

Unity classifies different game objects under specific "layers." This is mostly
useful for collision detection - e.g. when raycasting, you can choose to ignore
specific layers of objects. Which layers are used is determined by a 32-bit
bitmask, so only 32 layers may exist.

*/

using UnityEngine;
using System.Collections;

public class Layers {

    public const int Player = 1 << 8;
    public const int InteractiveObjects = 1 << 9;
    public const int PlayerTown = 1 << 10;

}
