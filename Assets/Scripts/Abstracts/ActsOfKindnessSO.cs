using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Act", menuName = "Acts of Kindness")]
public class ActsOfKindnessSO : ScriptableObject
{
        [TextArea(2,6)]
        [SerializeField] string activity = "Enter act of kindness text here";
        [SerializeField] int happiness;
        [SerializeField] Sprite activityImage;
        
        public string GetActivity()
        {
            return activity;
        }

        public int GetHappinessPoints()
        {
            return happiness;
        }
}
