using UnityEngine;

public class TapToKill : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<ITarget>(out var target))
                {
                    target.Kill();
                }
            }
        }
    }
}