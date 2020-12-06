using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool mouseEnabled = false;
    
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            enabled = true;
            return;
        }

        if (Input.GetKey(KeyCode.W) || mouseEnabled && Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.S) || mouseEnabled && Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.D) || mouseEnabled && Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey(KeyCode.A) || mouseEnabled && Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
        }

        var scroll = Input.GetAxis("Mouse ScrollWheel");

        var pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;
    }
}
