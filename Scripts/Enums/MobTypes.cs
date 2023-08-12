public enum MobType
{
  Undead,
  Animal,
  Demon,
  Monster,
  None,
}
public static class MobTypeUtility
{

  public static string ToString(MobType val)
  {
    switch (val)
    {
      case MobType.Undead: return "Undead";
      case MobType.Animal: return "Animal";
      case MobType.Demon: return "Demon";
      case MobType.Monster: return "Monster";
      case MobType.None: return "None";
      default: return "Unknown";
    }
  }
}