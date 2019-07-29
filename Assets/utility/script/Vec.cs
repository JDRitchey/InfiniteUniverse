using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
namespace VecExtensions {
  public static class Vec {
    public static Vector4 vec(float x, float y, float z, float w) {
      return new Vector4(x, y, z, w);
    }
    public static Vector3 vec(float x, float y, float z) {
      return new Vector3(x, y, z);
    }
    public static Vector2 vec(float x, float y) {
      return new Vector2(x, y);
    }
    public static Vector4 vec(double x, double y, double z, double w) {
      return new Vector4((float)x, (float)y, (float)z, (float)w);
    }
    public static Vector3 vec(double x, double y, double z) {
      return new Vector3((float)x, (float)y, (float)z);
    }
    public static Vector2 vec(double x, double y) {
      return new Vector2((float)x, (float)y);
    }

    public static float manhatten(this Vector2 v) {
      return Abs(v.x) + Abs(v.y);
    }
    public static float manhatten(this Vector3 v) {
      return Abs(v.x) + Abs(v.y) + Abs(v.z);
    }
    public static float manhatten(this Vector4 v) {
      return Abs(v.x) + Abs(v.y) + Abs(v.z) + Abs(v.w);
    }
    public static float maxNorm(this Vector2 v) {
      return Max(Abs(v.x), Abs(v.y));
    }
    public static float maxNorm(this Vector3 v) {
      return Max(Abs(v.x), Abs(v.y), Abs(v.z));
    }
    public static float maxNorm(this Vector4 v) {
      return Max(Abs(v.x), Abs(v.y), Abs(v.z), Abs(v.w));
    }


    public static Vector2 xx(this Vector2 v) {
      return new Vector2(v.x, v.x);
    }
    public static Vector2 xy(this Vector2 v) {
      return new Vector2(v.x, v.y);
    }

    public static Vector2 yx(this Vector2 v) {
      return new Vector2(v.y, v.x);
    }
    public static Vector2 yy(this Vector2 v) {
      return new Vector2(v.y, v.y);
    }

    public static Vector3 xxx(this Vector2 v) {
      return new Vector3(v.x, v.x, v.x);
    }
    public static Vector3 xxy(this Vector2 v) {
      return new Vector3(v.x, v.x, v.y);
    }

    public static Vector3 xyx(this Vector2 v) {
      return new Vector3(v.x, v.y, v.x);
    }
    public static Vector3 xyy(this Vector2 v) {
      return new Vector3(v.x, v.y, v.y);
    }

    public static Vector3 yxx(this Vector2 v) {
      return new Vector3(v.y, v.x, v.x);
    }
    public static Vector3 yxy(this Vector2 v) {
      return new Vector3(v.y, v.x, v.y);
    }

    public static Vector3 yyx(this Vector2 v) {
      return new Vector3(v.y, v.y, v.x);
    }
    public static Vector3 yyy(this Vector2 v) {
      return new Vector3(v.y, v.y, v.y);
    }


    public static Vector2 xx(this Vector3 v) {
      return new Vector2(v.x, v.x);
    }
    public static Vector2 xy(this Vector3 v) {
      return new Vector2(v.x, v.y);
    }
    public static Vector2 xz(this Vector3 v) {
      return new Vector2(v.x, v.z);
    }

    public static Vector2 yx(this Vector3 v) {
      return new Vector2(v.y, v.x);
    }
    public static Vector2 yy(this Vector3 v) {
      return new Vector2(v.y, v.y);
    }
    public static Vector2 yz(this Vector3 v) {
      return new Vector2(v.y, v.z);
    }

    public static Vector2 zx(this Vector3 v) {
      return new Vector2(v.z, v.x);
    }
    public static Vector2 zy(this Vector3 v) {
      return new Vector2(v.z, v.y);
    }
    public static Vector2 zz(this Vector3 v) {
      return new Vector2(v.z, v.z);
    }



    public static Vector3 xxx(this Vector3 v) {
      return new Vector3(v.x, v.x, v.x);
    }
    public static Vector3 xxy(this Vector3 v) {
      return new Vector3(v.x, v.x, v.y);
    }
    public static Vector3 xxz(this Vector3 v) {
      return new Vector3(v.x, v.x, v.z);
    }

    public static Vector3 xyx(this Vector3 v) {
      return new Vector3(v.x, v.y, v.x);
    }
    public static Vector3 xyy(this Vector3 v) {
      return new Vector3(v.x, v.y, v.y);
    }
    public static Vector3 xyz(this Vector3 v) {
      return new Vector3(v.x, v.y, v.z);
    }

    public static Vector3 xzx(this Vector3 v) {
      return new Vector3(v.x, v.z, v.x);
    }
    public static Vector3 xzy(this Vector3 v) {
      return new Vector3(v.x, v.z, v.y);
    }
    public static Vector3 xzz(this Vector3 v) {
      return new Vector3(v.x, v.z, v.z);
    }

    public static Vector3 yxx(this Vector3 v) {
      return new Vector3(v.y, v.x, v.x);
    }
    public static Vector3 yxy(this Vector3 v) {
      return new Vector3(v.y, v.x, v.y);
    }
    public static Vector3 yxz(this Vector3 v) {
      return new Vector3(v.y, v.x, v.z);
    }

    public static Vector3 yyx(this Vector3 v) {
      return new Vector3(v.y, v.y, v.x);
    }
    public static Vector3 yyy(this Vector3 v) {
      return new Vector3(v.y, v.y, v.y);
    }
    public static Vector3 yyz(this Vector3 v) {
      return new Vector3(v.y, v.y, v.z);
    }

    public static Vector3 yzx(this Vector3 v) {
      return new Vector3(v.y, v.z, v.x);
    }
    public static Vector3 yzy(this Vector3 v) {
      return new Vector3(v.y, v.z, v.y);
    }
    public static Vector3 yzz(this Vector3 v) {
      return new Vector3(v.y, v.z, v.z);
    }

    public static Vector3 zxx(this Vector3 v) {
      return new Vector3(v.z, v.x, v.x);
    }
    public static Vector3 zxy(this Vector3 v) {
      return new Vector3(v.z, v.x, v.y);
    }
    public static Vector3 zxz(this Vector3 v) {
      return new Vector3(v.z, v.x, v.z);
    }

    public static Vector3 zyx(this Vector3 v) {
      return new Vector3(v.z, v.y, v.x);
    }
    public static Vector3 zyy(this Vector3 v) {
      return new Vector3(v.z, v.y, v.y);
    }
    public static Vector3 zyz(this Vector3 v) {
      return new Vector3(v.z, v.y, v.z);
    }

    public static Vector3 zzx(this Vector3 v) {
      return new Vector3(v.z, v.z, v.x);
    }
    public static Vector3 zzy(this Vector3 v) {
      return new Vector3(v.z, v.z, v.y);
    }
    public static Vector3 zzz(this Vector3 v) {
      return new Vector3(v.z, v.z, v.z);
    }
  }
}