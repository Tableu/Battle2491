using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    public Vector2 dragAxis;
    public LayerMask LayerMask;
    private Vector2 dragOrigin;
    private bool dragging;
    private PlayerInputActions _playerInputActions;

    private void Start()
    {
        _playerInputActions = GlobalReferences.Instance.PlayerInputActions;
        _playerInputActions.Player.Hold.started += OnClick;
        _playerInputActions.Player.Hold.canceled += OnRelease;
    }

    private void Update()
    {
        if (dragging)
        {
            Vector2 pos = Camera.main.ScreenToViewportPoint(dragOrigin-_playerInputActions.UI.Point.ReadValue<Vector2>());
            Vector2 move = new Vector2(pos.x * dragSpeed*dragAxis.x, pos.y*dragSpeed*dragAxis.y);
            transform.Translate(move, Space.World);
        }
    }

    private void OnDestroy()
    {
        PlayerInputActions playerInputActions = GlobalReferences.Instance.PlayerInputActions;
        playerInputActions.Player.Hold.performed -= OnClick;
        playerInputActions.Player.Hold.canceled -= OnRelease;
    }

    private void OnClick(InputAction.CallbackContext callbackContext)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(_playerInputActions.UI.Point.ReadValue<Vector2>());
        var hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity, LayerMask);
        if (!hit && !dragging)
        {
            dragOrigin = _playerInputActions.UI.Point.ReadValue<Vector2>();
            dragging = true;
        }
    }

    private void OnRelease(InputAction.CallbackContext callbackContext)
    {
        transform.position = Camera.main.transform.position;
        dragging = false;
    }
}
