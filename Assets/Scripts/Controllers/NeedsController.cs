using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy, age;
    public int foodTickRate, happinessTickRate, energyTickRate, ageTickRate;
    public DateTime lastTimeFed, lastTimeHappy, lastTimeGainedEnergy, lastTimeAged;

    private void Awake()
    {
        try
        {
            Initialize(food, happiness, energy, age, foodTickRate, happinessTickRate, energyTickRate, ageTickRate, lastTimeFed, lastTimeHappy, lastTimeGainedEnergy, lastTimeAged);
            UpdatePetUI(food, happiness, energy, age);
        }
        catch (System.Exception)
        {
            Debug.Log("Initialize was not set to an object");
        }
    } 

    public void Initialize(int food, int happiness, int energy, int age,
        int foodTickRate, int happinessTickRate, int energyTickRate, int ageTickRate)
    {
        lastTimeFed = DateTime.Now;
        lastTimeHappy = DateTime.Now;
        lastTimeGainedEnergy = DateTime.Now;
        lastTimeAged = DateTime.Now;
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.age = age;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        this.ageTickRate = ageTickRate;
        // PetUIController.instance.UpdateImages(food, happiness, energy, age);
        // PetUIController.instance.UpdateText(food, happiness, energy, age);
        UpdatePetUI(food, happiness, energy, age);
    }

    public void Initialize(int food, int happiness, int energy, int age,
        int foodTickRate, int happinessTickRate, int energyTickRate, int ageTickRate,
        DateTime lastTimeFed, DateTime lastTimeHappy, DateTime lastTimeGainedEnergy, DateTime lastTimeAged)
    {

        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;
        this.lastTimeAged = lastTimeAged;

        this.food = food
            - foodTickRate
            * TickAmountSinceLastTimeToCurrentTime(lastTimeFed, TimingManager.instance.hourLength);

        this.happiness = happiness
            - happinessTickRate
            * TickAmountSinceLastTimeToCurrentTime(lastTimeHappy, TimingManager.instance.hourLength);
            
        this.energy = energy
            - energyTickRate
            * TickAmountSinceLastTimeToCurrentTime(lastTimeGainedEnergy, TimingManager.instance.hourLength);

        this.age = age
            + ageTickRate
            * TickAmountSinceLastTimeToCurrentTime(lastTimeAged, TimingManager.instance.hourLength);

        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        this.ageTickRate  = ageTickRate;

        if (this.food < 0) this.food = 0;
        if (this.happiness < 0) this.happiness = 0;
        if (this.energy < 0) this.energy = 0;
    }

    private void Update()
    {
        if(TimingManager.instance.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);
            ChangeAge(ageTickRate);
            // PetUIController.instance.UpdateImages(food, happiness, energy, age);
            // PetUIController.instance.UpdateText(food, happiness, energy, age);
            UpdatePetUI(food, happiness, energy, age);
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        if (amount > 0)
        {
            lastTimeFed = DateTime.Now;
        }
        if(food < 0)
        {
            // PetManager.instance.Die();
        }
        else if(food > 100) food = 100;
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;
        if (amount > 0)
        {
            lastTimeHappy = DateTime.Now;
        }
        if(happiness < 0)
        {
            // PetManager.instance.Die();
        }
        else if(happiness > 100)happiness = 100;

    }

    public void ChangeEnergy (int amount)
    {
        energy += amount;
        if (amount > 0)
        {
            lastTimeGainedEnergy = DateTime.Now;
        }
        if(energy < 0)
        {
            // PetManager.instance.Die();
        }
        else if(energy > 100) energy = 100;
    }

    public void ChangeAge(int amount)
    {
        age += amount;
        if (amount > 0)
        {
            lastTimeAged = DateTime.Now;
        }
        if (age > 20)
        {
            PetManager.instance.Age();
        }
        else if (age > 60)
        {
            PetManager.instance.Die();
        }
    }

    public void UpdatePetUI(int food, int happiness, int energy, int age)
    {
        PetUIController.instance.UpdateImages(food, happiness, energy, age);
        PetUIController.instance.UpdateText(food, happiness, energy, age);
    }

    public int TickAmountSinceLastTimeToCurrentTime(DateTime lastTime, float tickRateInSeconds)
    {
        DateTime currentDateTime = DateTime.Now;
        int dayOfYearDifference = currentDateTime.DayOfYear - lastTime.DayOfYear;

        if (currentDateTime.Year > lastTime.Year 
            || dayOfYearDifference >= 7) return 1500;

        int dayDifferenceSecondsAmount = dayOfYearDifference * 86400;
        if (dayOfYearDifference > 0) return Mathf.RoundToInt(dayDifferenceSecondsAmount/tickRateInSeconds);

        int hourDifferenceSecondsAmount = (currentDateTime.Hour - lastTime.Hour) * 3600;
        if (hourDifferenceSecondsAmount > 0) return Mathf.RoundToInt(hourDifferenceSecondsAmount/tickRateInSeconds);

        int minuteDifferenceSecondsAmount = (currentDateTime.Minute - lastTime.Minute) * 60;
        if (minuteDifferenceSecondsAmount > 0) return Mathf.RoundToInt(minuteDifferenceSecondsAmount/tickRateInSeconds);

        int secondDifferenceAmount = currentDateTime.Second - lastTime.Second;
        return Mathf.RoundToInt(secondDifferenceAmount/tickRateInSeconds);
    }
}
