using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/SeeFire")]
public class SeeFire: Leaf
{
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        Button1.IsFire += GetSeeFire;
    }
    private void GetSeeFire(bool status)
    {
        Debug.Log("Status arrived");
    }

    public override NodeResult Execute()
    {
        return NodeResult.success;
    }

}
