using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VecExtensions.Vec;
using static Mathd;

[RequireComponent(typeof(UniverseEntity))]
public class IntergalacticSuperstructure : MonoBehaviour, ExpandableRegion{
  public float regionSize = 1e+26f;
  public GalaxyFilament galaxyFilamentPrefab;
  public GalaxyFilamentNode galaxyFilamentNodePrefab;
  public InfiniteUniverse universe;

  UniverseEntity entity;
  List<Segment> segments = new List<Segment>();
  List<Node> nodes = new List<Node>();

  void OnDestroy() {
    gameObject.name += ".destroyed";
  }

  void Start() {
    if(!universe)
      universe = FindObjectOfType<InfiniteUniverse>();

    if(!entity)
      entity = GetComponent<UniverseEntity>();

    var seed = entity.UniversalPosition.GetHashCode();
    var rand = new System.Random(seed);
    int n = rand.Next(24, 64);

    double galaxyWindow = regionSize/100;
    double galaxyDensity = 1 / (galaxyWindow * galaxyWindow * galaxyWindow);
    nodes.Clear();
    for(int i = 0; i < n; i++) {
      nodes.Add(new Node {
        pos = vec(0.6*Lerp(-regionSize, regionSize, rand.NextDouble()), 0.6 * Lerp(-regionSize, regionSize, rand.NextDouble()), 0.6 * Lerp(-regionSize, regionSize, rand.NextDouble())),
        radius = ff(Lerp(regionSize / 2000, regionSize / 100, rand.NextDouble())),
        density = ff(Lerp(galaxyDensity / 100, galaxyDensity * 10, rand.NextDouble()))
      });
    }

    // we should generate m segments
    // each segment gets a random pair of nodes
    // we perform k passes wherein we choose m segments at random and attempt to replace the nodes with a closer pair (if the randomly chosen pair is further apart we keep what we had)
    int m = rand.Next(16, 64);

    segments.Clear();
    for(int i = 0; i < m; i++) {
      var a = nodes[rand.Next(0, n)];
      var b = nodes[rand.Next(0, n)];
      segments.Add(new Segment {
        a = a, b = b,
        radius = ff(0.9 * Lerp(a.radius, b.radius, 0.5)),
        density = ff(0.9 * Lerp(a.density, b.density, 0.5))
      });
    }

    int k = 2 * n + m;
    for(int i = 0; i < k; i++) {
      var seg = segments[rand.Next(0, m)];
      var a = nodes[rand.Next(0, n)];
      var b = nodes[rand.Next(0, n)];
      float d0 = (seg.a.pos - seg.b.pos).sqrMagnitude;
      float d1 = (a.pos - b.pos).sqrMagnitude;
      if(seg.a == seg.b || a != b && d1 < d0) {
        seg.a = a;
        seg.b = b;
      }
    }

    for(int i = m - 1; i >= 0; i--) {
      var seg = segments[i];
      if(seg.a == seg.b) {
        segments.RemoveAt(i);
      } else {
        for(int j = 0; j < i; j++) {
          var segJ = segments[j];
          if(seg.a == segJ.a && seg.b == segJ.b || seg.a == segJ.b && seg.b == segJ.a) {
            segments.RemoveAt(i);
            break;
          }
        }
      }
    }

    CreateFacade();
    ShowFacade();
  }

  List<GameObject> facadeChildren = new List<GameObject>();
  void CreateFacade() {
    foreach(var node in nodes) {
      var galaxyFilamentNode = Instantiate(galaxyFilamentNodePrefab, transform);
      galaxyFilamentNode.gameObject.name += ".facade";
      var filamentNodeEntity = galaxyFilamentNode.GetComponent<UniverseEntity>();
      GameObject.DestroyImmediate(filamentNodeEntity);

      galaxyFilamentNode.transform.localPosition = node.pos;

      galaxyFilamentNode.radius = node.radius;
      galaxyFilamentNode.density = node.density;
      facadeChildren.Add(galaxyFilamentNode.gameObject);
    }

    foreach(var segment in segments) {
      var galaxyFilament = Instantiate(galaxyFilamentPrefab, transform);
      galaxyFilament.gameObject.name += ".facade";
      var filamentEntity = galaxyFilament.GetComponent<UniverseEntity>();
      GameObject.DestroyImmediate(filamentEntity);

      var center = 0.5f * segment.a.pos + 0.5f * segment.b.pos;
      galaxyFilament.transform.localPosition = center;

      galaxyFilament.start = segment.a.pos - center;
      galaxyFilament.startRadius = segment.a.radius;
      galaxyFilament.startDensity = segment.a.density;

      galaxyFilament.end = segment.b.pos - center;
      galaxyFilament.endRadius = segment.b.radius;
      galaxyFilament.endDensity = segment.b.density;

      galaxyFilament.middleRadius = segment.radius;
      galaxyFilament.middleDensity = segment.density;
      facadeChildren.Add(galaxyFilament.gameObject);
    }
  }

  void ShowFacade() {

  }
  void HideFacade() {

  }


  List<GameObject> children = new List<GameObject>();
  void CreateChildren() {
    foreach(var node in nodes) {
      var galaxyFilamentNode = Instantiate(galaxyFilamentNodePrefab, universe.transform);
      var filamentNodeEntity = galaxyFilamentNode.GetComponent<UniverseEntity>();
      filamentNodeEntity.universe = universe;

      filamentNodeEntity.UniversalPosition = entity.UniversalPosition * filamentNodeEntity.precision / entity.precision + BigVec3.create(node.pos*filamentNodeEntity.precision);

      galaxyFilamentNode.radius = node.radius;
      galaxyFilamentNode.density = node.density;
      children.Add(galaxyFilamentNode.gameObject);
    }

    foreach(var segment in segments) {
      var galaxyFilament = Instantiate(galaxyFilamentPrefab, universe.transform);
      var filamentEntity = galaxyFilament.GetComponent<UniverseEntity>();
      filamentEntity.universe = universe;
      var center = 0.5f * segment.a.pos + 0.5f * segment.b.pos;

      filamentEntity.UniversalPosition = entity.UniversalPosition * filamentEntity.precision / entity.precision + BigVec3.create(center*filamentEntity.precision);

      galaxyFilament.start = segment.a.pos - center;
      galaxyFilament.startRadius = segment.a.radius;
      galaxyFilament.startDensity = segment.a.density;

      galaxyFilament.end = segment.b.pos - center;
      galaxyFilament.endRadius = segment.b.radius;
      galaxyFilament.endDensity = segment.b.density;

      galaxyFilament.middleRadius = segment.radius;
      galaxyFilament.middleDensity = segment.density;
      children.Add(galaxyFilament.gameObject);
    }
  }
  void ShowChildren() {

  }

  void HideChildren() {

  }


  public void CollapseRegion() {
    HideChildren();
    ShowFacade();
  }

  bool firstExpand = true;
  public void ExpandRegion() {
    if(firstExpand){
      firstExpand = false;
      CreateChildren();
    }
    HideFacade();
    ShowChildren();
  }

  class Node {
    public Vector3 pos;
    public float density;
    public float radius;
  }
  class Segment {
    public Node a;
    public Node b;
    public float density;
    public float radius;
  }
}
