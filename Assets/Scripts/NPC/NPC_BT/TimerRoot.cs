using System.Diagnostics;
using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Root/TimerRoot")]
public class TimedRoot : Root
{
    private Stopwatch stopwatch = new Stopwatch();

    public override NodeResult Execute()
    {
        stopwatch.Start();
        NodeResult result = base.Execute(); // Обход дерева
        stopwatch.Stop();

      UnityEngine.Debug.Log($"Full BT execution time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Reset();

        return result;
    }
}