using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mathd{
  public static double Lerp(double a, double b, double t) {
    return a * (1 - t) + b * t;
  }
  public static float ff(double d) {
    return (float)d;
  }
}
