using UnityEngine;
using System.Collections;

public class PerspectiveHandler : MonoBehaviour {

    /*
     * @author: Philipp Rösner
     * @date: 2017
     */

    /*
     * @description Handles changes in the current camera perspective and objects interacting with it
     */

    [Header("References")]
    public GameObject playerPrefab;

    [Header("Variables")]
    public Vector3 playerSpawn;
    public bool isPlayerOrShip;

    private GameObject player;

    //when the player has entered the ship, this would be a refence to the ship object; otherwise reference to the player object
    public GameObject currentObject;

    //reference to the camera of the ship to make it easier to deactivate it
    private Camera shipCamera;
    private ShipMovement shipMovement;

    void Start()
    {
        //at start the game is in 3rd person player mode
        //TODO when save system is created -> decide wether player has to be spawned in ship or not
        SetPlayerPerspective(playerSpawn, Quaternion.identity);
    }

    public void SetPlayerPerspective(Vector3 spawn, Quaternion rotation)
    {
        //need to deactivate camera of the ship (if there is one)
        if (shipCamera != null)
            shipCamera.gameObject.SetActive(false);

        //need to deactivate movement of the ship (if there is one)
        if (shipMovement != null)
            shipMovement.allowInput = false;

        player = (GameObject)Instantiate(playerPrefab, spawn, rotation);
        isPlayerOrShip = true;

        //set currentobject to player
        currentObject = player;
    }

    public void SetShipPerspective(Ship ship)
    {
        //destroy the player instance object because he is now in the ship
        Destroy(player);

        //activate camera of the ship; is deactivated by default
        shipCamera = ship.instance.transform.FindChild("Camera").GetComponent<Camera>();
        shipCamera.gameObject.SetActive(true);

        //activate movement
        shipMovement = ship.instance.GetComponent<ShipMovement>();
        shipMovement.allowInput = true;

        isPlayerOrShip = false;

        //set currentoject to ship
        currentObject = ship.instance;
    }
}
