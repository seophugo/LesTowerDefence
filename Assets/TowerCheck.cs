using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject spherePrefab; // Assign your sphere prefab in the Inspector

    // Name of the layer to check
    public string jamiroCubeLayerName = "jamiro cube";
    private int jamiroCubeLayer;

    void Start()
    {
        jamiroCubeLayer = LayerMask.NameToLayer(jamiroCubeLayerName);
        if (jamiroCubeLayer == -1)
        {
            Debug.LogWarning($"Layer '{jamiroCubeLayerName}' does not exist. Please create it in the Unity editor.");
        }
        // Disable this script if not on the correct layer
        if (gameObject.layer != jamiroCubeLayer)
        {
            enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    if (spherePrefab != null)
                    {
                        Debug.Log($"Replacing 'jamiro cube' with sphere at {transform.position}");
                        Instantiate(spherePrefab, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Debug.LogWarning("spherePrefab is not assigned in the Inspector.");
                    }
                }
            }
        }
    }
}