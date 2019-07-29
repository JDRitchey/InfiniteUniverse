using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UniverseEntity))]
public class EntityPhysics : MonoBehaviour{
  public float lightSpeed = 1000;
  public Vector3 velocity;
  UniverseEntity entity;
  Rigidbody body;

  void Start() {
    entity = GetComponent<UniverseEntity>();
    body = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    float dt = Time.deltaTime;
    entity.UniversalPosition += BigVec3.create(velocity*entity.universe.precision*Time.deltaTime);
  }
}
