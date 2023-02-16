using System.Diagnostics;
using System;

[Serializable]
public class Pet
{
    public string name, lastTimeFed, lastTimeHappy, lastTimeGainedEnergy, lastTimeAged;
    public int foodTickRate, happinessTickRate, energyTickRate, ageTickRate,
                food, happiness, energy, age;

    public Pet
        (
            string name,
            string lastTimeFed,
            string lastTimeHappy,
            string lastTimeGainedEnergy,
            string lastTimeAged,
            int food,
            int happiness,
            int energy,
            int age,
            int foodTickRate,
            int happinessTickRate,
            int energyTickRate,
            int ageTickRate
        )
    {
        this.name = name;
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;
        this.lastTimeAged = lastTimeAged;
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.age = age;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        this.ageTickRate = ageTickRate;
    }
}
