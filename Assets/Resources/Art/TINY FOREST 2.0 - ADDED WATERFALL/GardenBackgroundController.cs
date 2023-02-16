using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBackgroundController : MonoBehaviour
{
    public Sprite[] backs, middles, middleBacks, fronts, trees;
    public SpriteRenderer[] backsRenderers, middlesRenderers, middleBacksRenderers, frontRenderers, treeRenderers;
    public GameObject waterfallRenderer, pet;
    public GameObject[] tileMaps, waterfalls;
    Transform[] startingPositions;

    private void Start()
    {
        RandomizeBackground();
    }
    public void RandomizeBackground()
    {
        ChooseGraphicForRenderers(backsRenderers, backs);
        ChooseGraphicForRenderers(middlesRenderers, middles);
        ChooseGraphicForRenderers(middleBacksRenderers, middleBacks);
        ChooseGraphicForRenderers(frontRenderers, fronts);
        ChooseGraphicForRenderers(treeRenderers, trees);
        PickRandomTileMap();
        PickRandomWaterFall();
    }

    private void ChooseGraphicForRenderers(SpriteRenderer[] spriteRenderers, Sprite[] sprites)
    {
        foreach(SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
        }
    }

    private void PickRandomTileMap()
    {
        int randomInt = Random.Range(0,tileMaps.Length);
        tileMaps[randomInt].SetActive(true);
    }

    private void PickRandomWaterFall()
    {
        int randomInt = Random.Range(0, waterfalls.Length);
        waterfalls[randomInt].SetActive(true);
    }

    public void Initialize(Transform pet)
    {
        transform.position = Vector3.zero;
        pet.position = startingPositions[Random.Range(0,startingPositions.Length)].position;
    }
}

