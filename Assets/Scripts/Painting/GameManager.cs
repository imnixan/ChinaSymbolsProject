using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Painter drawCanvas;

    [SerializeField]
    private Symbol symbol;

    private Collider2D canvasCol;

    void Start()
    {
        canvasCol = drawCanvas.GetComponent<Collider2D>();
        StartPainting();
    }

    public float GetMaxPoints()
    {
        return symbol.GetMaxPoints();
    }

    private void StartPainting()
    {
        drawCanvas.gameObject.SetActive(true);
        symbol.DisableCollider();
    }

    public void StopPainting()
    {
        canvasCol.enabled = false;
        symbol.EnableCollider();
        if (drawCanvas.CheckCorrect())
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("Lose");
        }
    }
}
