using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    //Puntos de patrulla
    public Transform[] destinationPoints;
    public int destinationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //posicion del target como objetivo de IA
        //agent.destination = target.position;

        /*if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.destination = hit.point;
            }
        }*/

        //si la distancia entre la IA y el target es menos de 8, sigue al target
        if(Vector3.Distance(transform.position, target.position) < 10)
        {
            agent.destination = target.position;
        }

        if(Vector3.Distance(transform.position, target.position) < 2)
        {
            Debug.Log("Atacando");
        }

        else
        {
            //ve a la posicion de patrulla
            agent.destination = destinationPoints[destinationIndex].position;

            //si la distancia entre la IA y el destino es menor que 0.5
            if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < 0.5f)
            {
                //mientras el index sea inferior a la cantidad de puntos en el array pasa al siguiente punto
                if(destinationIndex < destinationPoints.Length - 1)
                {
                    destinationIndex++;
                }
                //si llegamos al maximo de puntos en el array nos pone el index a 0
                else
                {
                destinationIndex = 0;
                }
            }   
        }
    }
}