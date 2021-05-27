using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    [SerializeField] Pill m_PillPrefab;

    const float PILL_INTERVAL = 10f;
    float m_PillTimer;

    void Update()
    {
        UpdatePill();

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }
    }

    void UpdatePill() {
        if (m_PillTimer > PILL_INTERVAL){
            m_PillTimer = 0;

            NavMeshHit navHit;

            while (!NavMesh.SamplePosition(
                Random.insideUnitSphere * Random.Range(0f, PILL_INTERVAL)
                , out navHit, 5f, -1)) { }

            Vector3 position = navHit.position;
            position.y = 1.25f;
            GameObject.Instantiate(m_PillPrefab).transform.position = position;
        }
        else {
            m_PillTimer += Time.deltaTime;
        }
    }
}
