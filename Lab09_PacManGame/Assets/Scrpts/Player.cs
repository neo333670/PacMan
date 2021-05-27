using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool m_isInvincible = false;
    public bool IsInvincible { get { return m_isInvincible; } }

    const float INVINCIBLE_INTERVAL = 10f;
    float m_InvincibleTimer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            m_isInvincible = !m_isInvincible;
        }
        if (m_isInvincible) {
            if (m_InvincibleTimer > INVINCIBLE_INTERVAL) {
                m_isInvincible = false;
                this.GetComponent<MeshRenderer>().material.color = 
                    new Color(67f / 255f, 167f / 255f, 59f/ 255f);
            }
            m_InvincibleTimer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision){
        var pill = collision.collider.gameObject.GetComponent<Pill>();

        if (pill != null) {
            Destroy(pill.gameObject);
            m_isInvincible = true;
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;

            m_InvincibleTimer = 0;
        }

        var ghost = collision.collider.gameObject.GetComponent<Ghost>();

        if (ghost != null) {
            if (m_isInvincible) {
                GameObject.Destroy(ghost.gameObject);
            }
            else {
                Debug.Log("Game Over");
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
