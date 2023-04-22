using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DragAndRotate : MonoBehaviour
{
    public bool isActive = false;
    private Color _activeColor = new Color();
    private MeshRenderer _meshRenderer;


    [SerializeField] private Slider rotSpeed;
    [SerializeField] private TMP_Text speedText;
    private string speedTitle = "Speed: ";
    private float speedfloat = 0.02f;

    private void Start()
    {
        rotSpeed.value = speedfloat;
        speedText.text = speedTitle + speedfloat;
    }

    private void Update()
    {
        if (isActive == true)
        {
            _activeColor = Color.red;
            
            if (Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0);

                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(0f, -screenTouch.deltaPosition.x * speedfloat, 0f);
                    speedText.text = speedTitle + speedfloat;
                }

                if (screenTouch.phase == TouchPhase.Ended)
                {
                    isActive = false;
                }
            }
        }
        else
        {
            _activeColor = Color.white;
        }

        // _meshRenderer.material.color = _activeColor;
    }
}
