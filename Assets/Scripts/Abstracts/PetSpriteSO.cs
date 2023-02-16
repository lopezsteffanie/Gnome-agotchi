using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet Sprites", menuName = "Pet Sprites")]
public class PetSpriteSO : ScriptableObject
{
    [SerializeField] GameObject[] sprites = new GameObject[5];

    public GameObject GetEgg()
    {
        return sprites[0];
    }

    public GameObject GetBaby()
    {
        return sprites[1];
    }

    public GameObject GetKid()
    {
        return sprites[2];
    }

    public GameObject GetAdult()
    {
        return sprites[3];
    }

    public GameObject GetEndLife()
    {
        return sprites[4];
    }
}
