using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField]
  private GameObject enemyPrefab;

  public void spawnEnemy()
  {
    GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation);
  }
}
