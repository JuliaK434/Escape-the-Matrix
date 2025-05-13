using UnityEngine;
using MBT;

public class MBTStarter : MonoBehaviour
{
    public MonoBehaviourTree tree;

    void Start()
    {
        if (tree != null)
        {
        }
        else
        {
            Debug.LogWarning("Error on " + gameObject.name);
        }
    }
}