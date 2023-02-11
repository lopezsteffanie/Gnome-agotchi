using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reflections", menuName = "Reflections")]

public class ReflectionsSO : ScriptableObject
{
    [SerializeField] string reflectionTitle;
    [TextArea(2,6)]
    [SerializeField] string reflection = "Free form reflection";
    [SerializeField] int happiness;
    [SerializeField] Sprite activityImage;
    [SerializeField] string[] reflectionType = new string[6];
    [SerializeField] int reflectionTypeIndex;

    public string GetReflectionTitle()
    {
        return reflectionTitle;
    }
    public string GetReflection()
    {
        return reflection;
    }

    public int GetHappinessPoints()
    {
        return happiness;
    }

    public int GetReflectionIndex()
    {
        return reflectionTypeIndex;
    }

    public string GetReflectionType(int index)
    {
        return reflectionType[index];
    }
}
