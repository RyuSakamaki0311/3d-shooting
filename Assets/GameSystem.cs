using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField]
    private bool _drawMouseCursor;

    private void Start()
    {
        Cursor.visible = _drawMouseCursor;
    }
}
