using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Tower prefab
    private bool hasTower = false;  // Check of er al een toren staat

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Linker muisknop
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject && !hasTower)
                {
                    if (spherePrefab != null)
                    {
                        // Haal collider bounds van de cube op
                        Collider cubeCol = GetComponent<Collider>();
                        float topY = cubeCol.bounds.max.y; // bovenkant van de cube

                        // Spawnpositie = midden van de cube, maar bovenkant
                        Vector3 spawnPos = new Vector3(transform.position.x, topY, transform.position.z);

                        // Instantieer toren
                        GameObject tower = Instantiate(spherePrefab, spawnPos, Quaternion.identity);

                        // Zet de toren als child van de cube
                        tower.transform.SetParent(transform);

                        hasTower = true; // Markeer dat er nu een toren staat
                    }
                }
            }
        }
    }
}
