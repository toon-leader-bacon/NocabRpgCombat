public enum DamageType
{
  Bludgeon,
  Slash,
  Holy,
  Heal,
  None
}
public static class DamageTypeUtility
{

  public static string ToString(DamageType val)
  {
    switch (val)
    {
      case DamageType.Bludgeon: return "Bludgeon";
      case DamageType.Slash: return "Slash";
      case DamageType.Holy: return "Holy";
      case DamageType.Heal: return "Heal";
      case DamageType.None: return "None";
      default: return "Unknown";
    }
  }
}