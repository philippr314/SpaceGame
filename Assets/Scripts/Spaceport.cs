using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/*
 * @author: Philipp Rösner
 * @date: 2017
 */

/*
 * @description: The spaceport gives the player the ability to choose a spaceship and to step into it. 
 */

public class Spaceport : MonoBehaviour {

    [Header("Variables")]
    public float interactionRange = 5.0f;

    [Header("Positions")]
    public Vector3 shipSpawn;
    public Vector3 shipRotation;
    public Vector3 playerSpawn;
    public Quaternion playerRotation;

    [Header("References")]
    public Text actionText;
    public PerspectiveHandler perspectiveHandler;
    public ShipManager shipManager;

    private GameObject player;
    private Ship currentShip;
    private int shipIndex;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        SpawnShip();
	}
	
	// Update is called once per frame
	void Update () {
        Check();
	}

    private void Check()
    {
        if (CheckRange())
        {
            DisplayUI();
            CheckInput();
        }
        else
        {
            HideUI();
        }
    }

    private void SpawnShip()
    {
        currentShip = shipManager.shipList.ships[shipIndex];
        currentShip.instance = (GameObject)Instantiate(currentShip.prefab, shipSpawn, Quaternion.Euler(shipRotation));
        currentShip.instance.transform.SetParent(GameObject.Find("Ship").transform);
        shipIndex++;
    }

    private void CheckInput()
    {
        if (PlayerInput.instance.currentSet.GetKey("Action"))
        {
            if (perspectiveHandler.isPlayerOrShip)
                EnterShip();
            else ExitShip();
        }
    }

    private void EnterShip()
    {
        perspectiveHandler.SetShipPerspective(currentShip);
    }

    private void ExitShip()
    {
        perspectiveHandler.SetPlayerPerspective(playerSpawn, playerRotation);
        ResetShipPosition();
    }

    private void ResetShipPosition()
    {
        Rigidbody rb = currentShip.instance.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.position = shipSpawn;
        rb.rotation = Quaternion.Euler(shipRotation);
        rb.isKinematic = false;
    }

    private void DisplayUI()
    {
        if (actionText.IsActive() == false)
            actionText.gameObject.SetActive(true);

        actionText.text = "Press " + PlayerInput.instance.currentSet.FindKeyCode("Action") + " to enter spaceship";
    }


    private void HideUI()
    {
        actionText.gameObject.SetActive(false);
    }

    private bool CheckRange()
    {
        if (Vector3.Distance(this.transform.position, perspectiveHandler.currentObject.transform.position) <= interactionRange)
            return true;
        else return false;
    }
}
