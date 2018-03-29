using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC2 : MonoBehaviour {

    public Transform player;
    float distancefrom_player;
    public float look_range = 20.0f;
    public float agro_range = 10.0f;
    public float move_speed = 4.0f;
    public float damping = 6.0f;
    public float attack_range = 2.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distancefrom_player = Vector3.Distance(player.position, transform.position);

        if (distancefrom_player < look_range)
        {
            transform.LookAt(player);
        }

        if (distancefrom_player < agro_range)

        {
            attack();
        }
        if (distancefrom_player < attack_range)
        {
            stopMoving();
        }
    }

    void lookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attack()
    {
        transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
    }

    void stopMoving()
    {
        transform.Translate(Vector3.back * move_speed * Time.deltaTime);
    }
}