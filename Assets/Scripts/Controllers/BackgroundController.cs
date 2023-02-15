using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Sprite[] backs, middles, middleBacks, fronts;
    public SpriteRenderer[] backsRenderers, middlesRenderers, middleBacksRenderers, frontRenderers;

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
    }

    private void ChooseGraphicForRenderers(SpriteRenderer[] spriteRenderers, Sprite[] sprites)
    {
        foreach(SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
        }
    }
}
