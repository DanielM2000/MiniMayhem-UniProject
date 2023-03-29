using UnityEngine;
using UnityEngine.UI;
public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject buildPanel;
    public int towerLevel = 1;
    public bool isBuildMode = false;
    public void PlaceTower(Vector3 position)
    {
        GameObject newTower = Instantiate(towerPrefab, position, Quaternion.identity);
        newTower.GetComponent<TowerScript>().towerLevel = towerLevel;
    }
    public void UpgradeTower()
    {
        TowerScript[] towers = FindObjectsOfType<TowerScript>();

        foreach (TowerScript tower in towers)
        {
            tower.towerLevel++;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuildMode = !isBuildMode;

            if (isBuildMode)
            {
                buildPanel.SetActive(true);
            }
            else
            {
                buildPanel.SetActive(false);
            }
        }
    }
}