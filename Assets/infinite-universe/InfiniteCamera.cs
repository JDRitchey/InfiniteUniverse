using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InfiniteCamera : MonoBehaviour{
  public int cameraCount = 10;
  public float maxViewDistance = 1.0E+30f;
  private void Start() {
    var camera = GetComponent<Camera>();
  }


}
