using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public PetController pet;
    public NeedsController needsController;
    public float petMoveTimer, originalPetMoveTimer;
    public Transform[] waypoints;

    public static PetManager instance;

    private void Awake()
    {
        originalPetMoveTimer = petMoveTimer;

        if(instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in this Scene.");
    }

    private void Update()
    {
        if(petMoveTimer > 0)
        {
            petMoveTimer -= Time.deltaTime;
        }
        else
        {
        MovePetRoRandomWayPoint();
        petMoveTimer = originalPetMoveTimer;
        }
    }

    private void MovePetRoRandomWayPoint()
    {
        int randomWaypoint = Random.Range(0, waypoints.Length);
        pet.Move(waypoints[randomWaypoint].position);
    }

    public void Die()
    {
        Debug.Log("Dead");
    }

    public void Age()
    {
        Debug.Log("You have aged up");
    }
}
