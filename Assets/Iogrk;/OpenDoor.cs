using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float waitTime = 3f;
    public float speed = 5f;
    public Vector3 positionDelta = Vector3.zero;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;

    // Start is called before the first frame update
    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = _closedPosition + positionDelta;

        StartCoroutine(OpenClose());
    }

    IEnumerator OpenClose()
    {
        bool isOpen = false;
        Vector3 goal = _openPosition;

        while(true)
        {
            //if we real close to the goal, change the goal position to the closed position
            if(Vector3.Distance(transform.position, goal) < 0.1f)
            {
                isOpen =  !isOpen;
                if(isOpen)
                {
                    goal = _closedPosition;
                }
                else
                {
                    goal = _openPosition;
                }
              
                yield return new WaitForSeconds(waitTime);
            } 
            else //if we aint, make it move toward the goal lowkey on god no kizzy fr fr
            {
                transform.position = Vector3.MoveTowards(transform.position, goal , speed * Time.deltaTime );
                yield return null;//makes us wait for 1 frame lole
            }
        }
    }

}
