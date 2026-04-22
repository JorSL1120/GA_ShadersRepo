using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MouseColor : MonoBehaviour
{
    public Material material;
    public TextMeshProUGUI  textRGB;

    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = _cam.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            Vector3 local = transform.InverseTransformPoint( hit.point );
            float r = (local.x + 0.5f);
            float g = (local.y + 0.5f);
            float b = (local.z + 0.5f);

            Color color = new Color(r, g, b, 1f);

            material.SetColor("_Color", color);

            if (textRGB != null) textRGB.text = $"R:{r:F2} G:{g:F2} B:{b:F2}";
        }
    }
}
