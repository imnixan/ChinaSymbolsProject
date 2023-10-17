using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Painter drawCanvas;

    [SerializeField]
    private Collider2D symbolSample;

    private Collider2D canvasCol;

    void Start()
    {
        canvasCol = drawCanvas.GetComponent<Collider2D>();
        StartPainting();
    }

    private void StartPainting()
    {
        drawCanvas.gameObject.SetActive(true);
        symbolSample.enabled = false;
    }

    public void StopPainting()
    {
        canvasCol.enabled = false;
        symbolSample.enabled = true;
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
