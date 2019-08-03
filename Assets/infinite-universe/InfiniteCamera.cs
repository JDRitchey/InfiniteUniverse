using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCamera : MonoBehaviour{
  public Camera mainCamera;
  public int cameraCount = 4;

  private void Start() {
    for(int i = 0; i < cameraCount-1; i++) {
      var camera = Instantiate(mainCamera, transform);
      Destroy(camera.GetComponent<AudioListener>());
      if(i < cameraCount-2)
        camera.clearFlags = CameraClearFlags.Depth;
      camera.depth -= i;
      var worldScale = camera.GetComponent<CameraSpecificWorldScale>();
      worldScale.scalePower -= i;
    }
    mainCamera.clearFlags = CameraClearFlags.Depth;
  }


}
