using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpecificWorldScale : MonoBehaviour
{

  public double scaleBase = 10;
  public double scalePower = 1;

  new Camera camera;
  InfiniteUniverse universe;

  Matrix4x4 prevWorldMatrix;
  private void Start() {
    camera = GetComponent<Camera>();
    universe = GameObject.FindObjectOfType<InfiniteUniverse>();
  }

  private void OnPreCull() {
    float scale = (float)System.Math.Pow(scaleBase, scalePower);
    universe.transform.position = camera.transform.position - camera.transform.position * scale;
    universe.transform.localScale = new Vector3(scale, scale, scale);
  }
  
  private void OnPostRender() {
    universe.transform.position = Vector3.zero;
    universe.transform.localScale = Vector3.one;
  }

  
  //private void OnPreCull() {
  //  float scale = (float)System.Math.Pow(scaleBase, scalePower);
  //  camera.worldToCameraMatrix *= Matrix4x4.Scale(new Vector3(scale, scale, scale));
  //}
  //
  //private void OnPostRender() {
  //  camera.ResetWorldToCameraMatrix();
  //}
}
