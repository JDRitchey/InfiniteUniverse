using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VecExtensions.Vec;

public class GalaxyFilamentNode : MonoBehaviour {
  public float radius;
  public float density;

  public Transform filamentNodeModelPrefab;
  void Start() {
    var filamentNodeModel = Instantiate(filamentNodeModelPrefab, transform);
    filamentNodeModel.localScale = vec(radius, radius, radius);
  }
}
