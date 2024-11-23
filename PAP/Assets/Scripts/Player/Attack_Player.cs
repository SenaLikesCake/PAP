using UnityEngine;

public class Attack_Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if left mouse button was pressed
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left-click.");
    }
}
