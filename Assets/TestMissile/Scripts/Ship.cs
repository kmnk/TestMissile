using UnityEngine;

public class Ship: MonoBehaviour
{

    [SerializeField]
    MissileLauncher launcher;

    [SerializeField]
    GameObject target;

    [SerializeField]
    bool playable;

    void Update()
    {
        if (playable && Input.GetKey("space"))
        {
            launcher.Launch(target, transform.position, transform.rotation);
        }
    }

}
