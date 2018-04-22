using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions {
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
