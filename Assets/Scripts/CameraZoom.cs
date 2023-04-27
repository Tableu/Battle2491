using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public float Speed;
    public float MinSize;
    public float MaxSize;
    private void Start()
    {
        PlayerInputActions playerInputActions = GlobalReferences.Instance.PlayerInputActions;
        playerInputActions.Player.Zoom.performed += Zoom;
    }

    private void Zoom(InputAction.CallbackContext callbackContext)
    {
        float value = callbackContext.ReadValue<float>();
        
        VirtualCamera.m_Lens.OrthographicSize += Mathf.Sign(value)*Speed;
        if (VirtualCamera.m_Lens.OrthographicSize < MinSize)
        {
            VirtualCamera.m_Lens.OrthographicSize = MinSize;
        }
        
        if (VirtualCamera.m_Lens.OrthographicSize > MaxSize)
        {
            VirtualCamera.m_Lens.OrthographicSize = MaxSize;
        }
    }
}
