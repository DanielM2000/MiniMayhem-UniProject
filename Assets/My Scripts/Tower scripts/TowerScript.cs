using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject buildPanel;
    public int towerLevel = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildPanel.activeSelf)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject newTower = Instantiate(towerPrefab, hit.point, Quaternion.identity);
                newTower.GetComponent<TowerScript>().towerLevel = towerLevel;
            }
        }
    }

    public void UpgradeTower()
    {
        towerLevel++;

        // Modify the tower's appearance and functionality based on the level
        // For example, increase its range, damage, and fire rate
    }
}
