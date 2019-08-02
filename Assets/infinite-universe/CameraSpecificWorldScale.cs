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

  Dictionary<UniverseEntity, ScaleData> scaleDataMap = new Dictionary<UniverseEntity, ScaleData>();

  private void OnPreCull() {
    var entities = FindObjectsOfType<UniverseEntity>();

    foreach(var entity in entities) {
      double cameraScaling = System.Math.Pow(scaleBase, scalePower);
      double cameraUnitScaling = (cameraScaling * entity.unitSize);
      bool tooLarge = cameraUnitScaling > 1;

      scaleDataMap.Add(entity, new ScaleData {
        originalPosition = entity.transform.position,
        originalScale = entity.transform.localScale
      });
      if(tooLarge) {
        entity.transform.position = camera.transform.position;
        entity.transform.localScale = Vector3.zero;
      } else {
        entity.transform.position = Vector3.Lerp(camera.transform.position, entity.transform.position*(float)entity.unitSize, (float)cameraScaling);
        entity.transform.localScale *= (float)cameraUnitScaling;
      }
    }
  }
  
  private void OnPostRender() {
    foreach(var pair in scaleDataMap) {
      var entity = pair.Key;
      var scaleData = pair.Value;
      entity.transform.position = scaleData.originalPosition;
      entity.transform.localScale = scaleData.originalScale;
    }
    scaleDataMap.Clear();
  }

  private class ScaleData {
    public Vector3 originalPosition;
    public Vector3 originalScale;
  }
}
