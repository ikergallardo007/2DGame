using UnityEngine;
using Unity.Cinemachine;

public class CameraVerticalLimit : CinemachineExtension
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private float minWorldY = 0f;
    #endregion

    #region Unity Callbacks
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime)
    {
        if (stage != CinemachineCore.Stage.Finalize)
            return;

        float cameraHalfHeight = state.Lens.OrthographicSize;

        float minimumCameraY = minWorldY + cameraHalfHeight;

        Vector3 position = state.GetCorrectedPosition();

        if (position.y < minimumCameraY)
        {
            position.y = minimumCameraY;

            state.RawPosition = position;
            state.PositionCorrection = Vector3.zero;
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    #endregion
}
