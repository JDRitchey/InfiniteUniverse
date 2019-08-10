using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BigVec3.Util;
using BigInteger = System.Numerics.BigInteger;

public class UniverseEntity : MonoBehaviour{
  public InfiniteUniverse universe;
  InfiniteUniverse Universe {
    get {
      if(!universe)
        universe = FindObjectOfType<InfiniteUniverse>();
      return universe;
    }
  }

  public long precision = 10000;
  public double unitSize = 1;

  BigVec3 universalPosition;
  Vector3 localPosition;

  public BigVec3 UniversalPosition {
    get {
      return universalPosition;
    }
    set {
      universalPosition = value;
      UpdateGameObjectPosition();
    }
  }

  private void Start() {
    if(!universe)
      universe = FindObjectOfType<InfiniteUniverse>();
    if(localPosition != transform.position) {
      universalPosition = BigVec3.create(transform.position * precision);
      localPosition = transform.position;
    }
  }

  void LateUpdate() {
    if (localPosition != transform.position) {
      universalPosition += BigVec3.create((transform.position - localPosition) * precision);
      localPosition = transform.position;
    }
  }

  public void UpdateGameObjectPosition() {
    transform.position = vec((universalPosition - Universe.OriginOffset * new BigInteger(Universe.observer.unitSize * precision) / new BigInteger(unitSize * Universe.observer.precision))) / precision;
    localPosition = transform.position;
  }
}
