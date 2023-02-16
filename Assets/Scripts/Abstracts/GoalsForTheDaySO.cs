using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Goal", menuName = "Goals for the Day")]
public class GoalsForTheDaySO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string goal = "Add my own goal";
    [SerializeField] int happiness;
    [SerializeField] Sprite goalImage;
    [SerializeField] string[] goalType = new string[6];
    [SerializeField] int goalTypeIndex;

    public string GetGoal()
    {
        return goal;
    }

    public int GetHappinessPoints()
    {
        return happiness;
    }

    public int GetGoalIndex()
    {
        return goalTypeIndex;
    }

    public string GetGoalType(int index)
    {
        return goalType[index];
    }
}
