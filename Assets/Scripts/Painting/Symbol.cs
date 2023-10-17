using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer symbol;

    [SerializeField]
    private SpriteRenderer sample;

    [SerializeField]
    private float maxPoints;

    [SerializeField]
    private string meaning;

    private PolygonCollider2D collider;

    private void Start()
    {
        collider = symbol.gameObject.AddComponent<PolygonCollider2D>();
        DisableCollider();
    }

    public void EnableCollider()
    {
        collider.enabled = true;
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }

    public float GetMaxPoints()
    {
        return maxPoints;
    }

    public string GetMeaning()
    {
        return meaning;
    }
}
