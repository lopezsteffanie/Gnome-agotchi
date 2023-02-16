using UnityEngine;

public class EndGamePetManager : MonoBehaviour
{
    public PetController pet;
    public float petMoveTimer, originalPetMoveTimer;
    public Transform[] startingPositions;
    public static EndGamePetManager instance;

    // private void Awake()
    // {
    //     originalPetMoveTimer = petMoveTimer;

    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else Debug.LogWarning("More than one EndGamePetManager in this Scene.");
    // }

    // private void Update()
    // {
    //     if(petMoveTimer > 0)
    //     {
    //         petMoveTimer -= Time.deltaTime;
    //     }
    //     else
    //     {
    //         MovePetToRandomWayPoint();
    //         petMoveTimer = originalPetMoveTimer;
    //     }
    // }
    // private void MovePetToRandomWayPoint()
    // {
    //     pet.position = startingPositions[Random.Range(0, startingPositions.Length)].position;
    // }

    private void Initialize(Transform pet)
    {
        transform.position = Vector3.zero;
        pet.position = startingPositions[Random.Range(0,startingPositions.Length)].position;
    }
}
