using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    private Database database;
    public NeedsController needsController;
    // public PetNameController petNameController;

    private void Awake()
    {
        database = new Database();
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one DatabaseManager in this Scene");
    }

    private void Update()
    {
        if (TimingManager.instance.gameHourTimer < 0)
        { 
            Pet pet = new Pet
            (
                // petNameController.petName.ToString(),
                needsController.lastTimeFed.ToString(),
                needsController.lastTimeHappy.ToString(),
                needsController.lastTimeGainedEnergy.ToString() ,
                needsController.food,
                needsController.happiness,
                needsController.energy
            );
            SavePet(pet);
        }
    }

    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null)
        {
            needsController.Initialize
                (
                    pet.food,
                    pet.happiness,
                    pet.energy,
                    5,2,1,
                    DateTime.Parse(pet.lastTimeFed),
                    DateTime.Parse(pet.lastTimeHappy),
                    DateTime.Parse(pet.lastTimeGainedEnergy)
                );
            // petNameController.Initialize
            //     (
            //         pet.petName
            //     );
        }
    }

    public void SavePet(Pet pet)
    {
        database.SaveData("pet", pet);
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;
        database.LoadData<Pet>("pet", (pet)=>
        {
            returnValue = pet;
        });
        return returnValue;
    }
}
