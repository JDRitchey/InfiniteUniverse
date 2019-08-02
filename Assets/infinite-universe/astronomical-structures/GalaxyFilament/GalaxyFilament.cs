using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VecExtensions.Vec;

[RequireComponent(typeof(UniverseEntity))]
public class GalaxyFilament : MonoBehaviour{
  public Vector3 start;
  public Vector3 end;

  public float startDensity;
  public float endDensity;
  public float middleDensity;

  public float startRadius;
  public float endRadius;
  public float middleRadius;

  public Transform filamentModel;

  void Start() {
    // arrange the filamentModels so that they have same radius as specified and go through both the start and end points
    // start and end are in relative coordinates, with origin at the very middle of the filament
    // filamentModel shall be a capsule with height 1 and radius 1, which we then scale and rotate to meet constraints
    var startModel = Instantiate(filamentModel, transform);
    startModel.localPosition = Vector3.zero;
    startModel.localRotation = Quaternion.LookRotation(start);
    startModel.localScale = vec(startRadius, startRadius, start.magnitude);

    var endModel = Instantiate(filamentModel, transform);
    endModel.localPosition = Vector3.zero;
    endModel.localRotation = Quaternion.LookRotation(end);
    endModel.localScale = vec(endRadius, endRadius, end.magnitude);
  }
}
