using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BigVec3.Util;
using BigInteger = System.Numerics.BigInteger;

public class UniverseEntity : MonoBehaviour{
  public InfiniteUniverse universe;
  public long precision = 10000;
  public long unitSize = 1;

  BigVec3 universalPosition;
  Vector3 localPosition;

  public BigVec3 UniversalPosition {
    get { return universalPosition; }
    set { universalPosition = value; UpdateGameObjectPosition(); }
  }

  private void Start() {
    if (!universe)
      universe = FindObjectOfType<InfiniteUniverse>();
    universalPosition = BigVec3.create(transform.position * precision);
    localPosition = transform.position;
    universe.registerEntity(this);
  }

  void LateUpdate() {
    if (localPosition != transform.position) {
      universalPosition += BigVec3.create((transform.position - localPosition) * precision);
      localPosition = transform.position;
    }
  }

  private void OnDestroy() {
    universe.unregisterEntity(this);
  }

  public void UpdateGameObjectPosition() {
    transform.position = vec((universalPosition - universe.OriginOffset * universe.observer.unitSize * precision / unitSize / universe.observer.precision )) / precision;
    localPosition = transform.position;
  }
}
