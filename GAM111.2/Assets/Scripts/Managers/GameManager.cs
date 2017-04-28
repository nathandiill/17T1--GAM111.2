using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Classes;
    public GameObject[] PlayerOneSlots;
    public GameObject[] PlayerTwoSlots;
    public Vector3[] Slots;
    public Quaternion pieceRotation = Quaternion.AngleAxis(180, Vector3.up);

    void Start ()
    {
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[0], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[1], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[2], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[3], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[4], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[5], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[6], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[7], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[8], pieceRotation);
        Instantiate(Classes[UnityEngine.Random.Range(0, 3)], Slots[9], pieceRotation);
    }
	
	void Update ()
    {
		
	}
}
