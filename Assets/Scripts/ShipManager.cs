using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * @author: Philipp Rösner
 * @date: 2017
 */

/*
 * @description Database for all types of ships in the game
 */

public class ShipManager : MonoBehaviour {

    public ShipList shipList;

	// Use this for initialization
	void Start () {
        shipList = new ShipList();
        shipList.AssignPrefabs();
	}

}

[System.Serializable]
public class ShipList
{
    public List<Ship> ships;

    public ShipList()
    {
        ships = new List<Ship>();
        ships.Add(new SpaceFighter());
        ships.Add(new Destroyer());
    }

    public void AssignPrefabs()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].prefab = (GameObject)Resources.Load<GameObject>(ships[i].GetType().FullName);
        }
    }
   
}

[System.Serializable]
public class Ship
{
    public int health;
    public int damage;
    public GameObject prefab;
    public GameObject instance;
}

[System.Serializable]
public class SpaceFighter : Ship
{
    public SpaceFighter()
    {
        health = 100;
        damage = 100;
        prefab = null;
        instance = null;
    }

}

[System.Serializable]
public class Destroyer : Ship
{
    public Destroyer()
    {
        health = 300;
        damage = 100;
        prefab = null;
        instance = null;
    }
}


 