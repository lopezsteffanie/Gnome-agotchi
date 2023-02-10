using System.Diagnostics;
using System;

[Serializable]
public class Pet
{
    // public string inputGnomeName, lastTimeFed, lastTimeHappy, lastTimeGainedEnergy;
    public string lastTimeFed, lastTimeHappy, lastTimeGainedEnergy;
    public int food, happiness, energy;

    public Pet
        (
            // string inputGnomeName,
            string lastTimeFed,
            string lastTimeHappy,
            string lastTimeGainedEnergy,
            int food,
            int happiness,
            int energy
        )
    {
        // this.inputGnomeName = inputGnomeName;
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
    }
}
