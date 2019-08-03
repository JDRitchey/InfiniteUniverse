using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpecificWorldScale : MonoBehaviour
{

  public double scaleBase = 10;
  public double scalePower = 1;

  new Camera camera;

  Matrix4x4 prevWorldMatrix;
  private void Start() {
    camera = GetComponent<Camera>();
  }

  ScaleData[] scaleData = new ScaleData[0];

  private void OnPreCull() {
    var entities = FindObjectsOfType<UniverseEntity>();
    if(entities.Length > scaleData.Length)
      scaleData = new ScaleData[entities.Length];
    else if(entities.Length < scaleData.Length / 2)
      scaleData = new ScaleData[entities.Length];
    int i = 0;
    foreach(var entity in entities) {
      double cameraScaling = System.Math.Pow(scaleBase, scalePower);
      double cameraUnitScaling = (cameraScaling * entity.unitSize);
      bool tooLarge = cameraUnitScaling > 1;

      scaleData[i++] = new ScaleData {
        entity = entity,
        originalPosition = entity.transform.position,
        originalScale = entity.transform.localScale
      };
      if(tooLarge) {
        entity.transform.position = camera.transform.position;
        entity.transform.localScale = Vector3.zero;
      } else {
        entity.transform.position = Vector3.Lerp(camera.transform.position, entity.transform.position*(float)entity.unitSize, (float)cameraScaling);
        entity.transform.localScale *= (float)cameraUnitScaling;
      }
    }
    while(i < scaleData.Length){
      scaleData[i] = null;
      ++i;
    }
  }
  
  private void OnPostRender() {
    for(int i = 0; i < scaleData.Length; i++) {
      var data = scaleData[i];
      if(data == null)
        break;
      var entity = data.entity;
      entity.transform.position = data.originalPosition;
      entity.transform.localScale = data.originalScale;
    }
  }


  private class ScaleData {
    public UniverseEntity entity;
    public Vector3 originalPosition;
    public Vector3 originalScale;
  }
}
