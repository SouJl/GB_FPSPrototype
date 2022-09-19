using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    private Camera _miniMapCamera;

    private void Awake()
    {
        _playerPos = Camera.main.transform;
        _miniMapCamera = GetComponent<Camera>();

        transform.parent = null;
        transform.rotation = Quaternion.Euler(90.0f, 0, 0);
        transform.position = _playerPos.position + new Vector3(0, 20f, 0);

        var rt = Resources.Load<RenderTexture>("MiniMapTexture");
        _miniMapCamera.targetTexture = rt;
    }


    private void LateUpdate()
    {
        var newPosition = _playerPos.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90, _playerPos.eulerAngles.y, 0);
    }
}
