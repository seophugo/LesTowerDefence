using UnityEngine;

public class Mousecheck : MonoBehaviour
{
    [SerializeField] private LayerMask _rayLayer;
    [SerializeField] private GameObject _tower;

    private float _distance = Mathf.Infinity;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _distance, _rayLayer))
            {
                Instantiate(_tower, hit.transform.position, Quaternion.identity);
            }
        }
    }
}