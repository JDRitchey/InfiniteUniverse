using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class InfiniteUniverse : MonoBehaviour{
  public UniverseEntity observer;
  BigVec3 originOffset = new BigVec3();
  public BigVec3 OriginOffset { get { return originOffset; } }
  public readonly long offsetRegionSize = 10000000;

  HashSet<UniverseEntity> entities = new HashSet<UniverseEntity>();

  public void registerEntity(UniverseEntity entity) {
    entities.Add(entity);
  }
  public void unregisterEntity(UniverseEntity entity) {
    entities.Remove(entity);
  }

  void Update() {
    var observerOffset = observer.UniversalPosition - OriginOffset;
    if(BigInteger.Abs(observerOffset.x) > offsetRegionSize || BigInteger.Abs(observerOffset.y) > offsetRegionSize || BigInteger.Abs(observerOffset.z) > offsetRegionSize) {
      originOffset = observer.UniversalPosition;
      foreach(UniverseEntity entity in entities)
        entity.UpdateGameObjectPosition();
    }
  }
}
