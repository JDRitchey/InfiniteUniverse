using System.Numerics;
using UnityEngine;

public struct BigVec3 {
  public readonly BigInteger x;
  public readonly BigInteger y;
  public readonly BigInteger z;

  public static BigVec3 create(BigInteger x, BigInteger y, BigInteger z) {
    return new BigVec3(x, y, z);
  }
  public static BigVec3 create(UnityEngine.Vector3 v) {
    return new BigVec3(new BigInteger(v.x), new BigInteger(v.y), new BigInteger(v.z));
  }
  public BigVec3(BigInteger x, BigInteger y, BigInteger z) {
    this.x = x;
    this.y = y;
    this.z = z;
  }
  public static BigVec3 operator +(BigVec3 a, BigVec3 b) {
    return create(a.x + b.x, a.y + b.y, a.z + b.z);
  }
  public static BigVec3 operator +(BigVec3 a, BigInteger b) {
    return create(a.x + b, a.y + b, a.z + b);
  }
  public static BigVec3 operator +(BigInteger a, BigVec3 b) {
    return create(a + b.x, a + b.y, a + b.z);
  }
  public static BigVec3 operator -(BigVec3 a, BigVec3 b) {
    return create(a.x - b.x, a.y - b.y, a.z - b.z);
  }
  public static BigVec3 operator -(BigVec3 a, BigInteger b) {
    return create(a.x - b, a.y - b, a.z - b);
  }
  public static BigVec3 operator -(BigInteger a, BigVec3 b) {
    return create(a - b.x, a - b.y, a - b.z);
  }
  public static BigVec3 operator -(BigVec3 a) {
    return create(-a.x, -a.y, -a.z);
  }
  public static BigVec3 operator *(BigVec3 a, BigVec3 b) {
    return create(a.x * b.x, a.y * b.y, a.z * b.z);
  }
  public static BigVec3 operator *(BigVec3 a, BigInteger b) {
    return create(a.x * b, a.y * b, a.z * b);
  }
  public static BigVec3 operator /(BigInteger a, BigVec3 b) {
    return create(a / b.x, a / b.y, a / b.z);
  }
  public static BigVec3 operator /(BigVec3 a, BigVec3 b) {
    return create(a.x / b.x, a.y / b.y, a.z / b.z);
  }
  public static BigVec3 operator /(BigVec3 a, BigInteger b) {
    return create(a.x / b, a.y / b, a.z / b);
  }
  public static BigVec3 operator %(BigInteger a, BigVec3 b) {
    return create(a % b.x, a % b.y, a % b.z);
  }
  public static BigVec3 operator %(BigVec3 a, BigVec3 b) {
    return create(a.x % b.x, a.y % b.y, a.z % b.z);
  }
  public static BigVec3 operator %(BigVec3 a, BigInteger b) {
    return create(a.x % b, a.y % b, a.z % b);
  }

  public static bool operator ==(BigVec3 a, BigVec3 b) {
    return a.x == b.x && a.y == b.y && a.z == b.z;
  }
  public static bool operator !=(BigVec3 a, BigVec3 b) {
    return a.x != b.x || a.y != b.y || a.z != b.z;
  }

  private static BigInteger BigSqrt(BigInteger n) {
    BigInteger odd = 1;
    BigInteger result = 0;
    while (n >= odd) {
      n -= odd;
      odd += 2;
      result++;
    }
    return result;
  }
  public BigInteger magnitude2 { get { return x * x + y * y + z * z; } }
  public BigInteger magnitude { get { return BigSqrt(magnitude2); } }

  public static readonly BigVec3 zero = new BigVec3(0, 0, 0);
  public static readonly BigVec3 one = new BigVec3(1, 1, 1);
  public static readonly BigVec3 right = new BigVec3(1, 0, 0);
  public static readonly BigVec3 up = new BigVec3(0, 1, 0);
  public static readonly BigVec3 forward = new BigVec3(0, 0, 1);
  public static readonly BigVec3 left = new BigVec3(-1, 0, 0);
  public static readonly BigVec3 down = new BigVec3(0, -1, 0);
  public static readonly BigVec3 back = new BigVec3(0, 0, -1);

  public override string ToString() {
    return base.ToString()+"("+x+", "+y+", "+z+")";
  }
  public override int GetHashCode() {
    int hash = 17;
    hash = hash * 31 + x.GetHashCode();
    hash = hash * 31 + y.GetHashCode();
    hash = hash * 31 + z.GetHashCode();
    return hash;
  }
  public override bool Equals(object obj) {
    if (!(obj is BigVec3))
      return false;
    return this == (BigVec3)obj;
  }

  public static class Util {
    public static UnityEngine.Vector3 vec(BigVec3 bigvec) {
      return new UnityEngine.Vector3((float)bigvec.x, (float)bigvec.y, (float)bigvec.z);
    }
  }
}
