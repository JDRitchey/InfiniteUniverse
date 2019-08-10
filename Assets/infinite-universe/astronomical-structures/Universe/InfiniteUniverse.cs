using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class InfiniteUniverse : MonoBehaviour{
  public UniverseEntity observer;

  public IntergalacticSuperstructure intergalacticSuperstructurePrefab;
  public int superstructureRegionSize = 100;
  public double superstructureUnitSize = 1e24;
  public long superstructurePrecision = 10000;

  BigVec3 originOffset = new BigVec3();
  public BigVec3 OriginOffset { get { return originOffset; } }
  public readonly long offsetRegionSize = 100000;

  Dictionary<BigVec3, IntergalacticSuperstructure> superstructures = new Dictionary<BigVec3, IntergalacticSuperstructure>();

  void Update() {
    var entities = FindObjectsOfType<UniverseEntity>();
    var observerOffset = observer.UniversalPosition - OriginOffset;
    if(BigInteger.Abs(observerOffset.x) > offsetRegionSize || BigInteger.Abs(observerOffset.y) > offsetRegionSize || BigInteger.Abs(observerOffset.z) > offsetRegionSize) {
      originOffset = observer.UniversalPosition;
      foreach(UniverseEntity entity in entities) 
        entity.UpdateGameObjectPosition();
    }

    updateVisible();
  }

  void updateVisible() {
    var visibleSuperstructurePositions = new HashSet<BigVec3>();

    var superstructureCenter = observer.UniversalPosition/observer.precision;
    superstructureCenter = superstructureCenter/superstructureRegionSize*superstructureRegionSize;
    int n = 2;
    int nn = (n*2+1);
    int n3 = nn*nn*nn;
    for(int i = -n; i <= n; i++) {
      var x = superstructureCenter.x + i*superstructureRegionSize;
      for(int j = -n; j <= n; j++) {
        var y = superstructureCenter.y + j*superstructureRegionSize;
        for(int k = -n; k <= n; k++) {
          var z = superstructureCenter.z + k*superstructureRegionSize;
          var superstructurePos = new BigVec3(x, y, z) * superstructurePrecision;
          visibleSuperstructurePositions.Add(superstructurePos);
          if(!superstructures.ContainsKey(superstructurePos) && superstructures.Count < n3) {
            var newSuperstructure = Instantiate(intergalacticSuperstructurePrefab, transform);
            newSuperstructure.universe = this;
            newSuperstructure.regionSize = superstructureRegionSize;
            var newEntity = newSuperstructure.GetComponent<UniverseEntity>();
            newEntity.universe = this;
            newEntity.unitSize = superstructureUnitSize;
            newEntity.precision = superstructurePrecision;
            newEntity.UniversalPosition = superstructurePos;
            superstructures.Add(superstructurePos, newSuperstructure);
          }
        }
      }
    }

    foreach(var pos in new List<BigVec3>(superstructures.Keys)) {
      if(!visibleSuperstructurePositions.Contains(pos)) {
        var oldSuperstructure = superstructures[pos];
        Destroy(oldSuperstructure.gameObject);
        superstructures.Remove(pos);
      }
    }
  }
}
