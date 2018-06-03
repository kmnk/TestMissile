using UnityEngine;
using System.Collections.Generic;

public class MissileLauncher : MonoBehaviour
{

    [SerializeField]
    Missile original;

    List<GameObject> missiles = new List<GameObject>();

    public void Launch(GameObject target, Vector3 position, Quaternion rotation)
    {
        original.Target = target;
        var instance = Object.Instantiate(original.gameObject, position, rotation);
        instance.transform.SetParent(transform);
        missiles.Add(instance);
    }

    private void OnGUI()
    {
        GUILayout.Label( "\nMissiles: " + missiles.Count.ToString() );
    }

}
