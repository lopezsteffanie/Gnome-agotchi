using System.Diagnostics;
using System;

[Serializable]
public class Pet
{
    public string petName, lastTimeFed, lastTimeHappy, lastTimeGainedEnergy;
    public int food, happiness, energy;

    public Pet
        (
            // string petName,
            string lastTimeFed,
            string lastTimeHappy,
            string lastTimeGainedEnergy,
            int food,
            int happiness,
            int energy
        )
    {
        // this.petName = petName;
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
    }
}
