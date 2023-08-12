public enum NocabmonStat
{
  HP,
  Attack,
  Defense,
  SpecialAttack,
  SpecialDefense,
  Speed
}

public static class NocabmonStatUtility
{
  public static string ToString(NocabmonStat val)
  {
    switch (val)
    {
      case NocabmonStat.HP: return "HP";

      case NocabmonStat.Attack: return "Attack";
      case NocabmonStat.Defense: return "Defense";
      case NocabmonStat.SpecialAttack: return "SpecialAttack";
      case NocabmonStat.SpecialDefense: return "SpecialDefense";
      
      case NocabmonStat.Speed: return "Speed";

      default: return "Unknown";
    }
  }
}

public class NocabmonStatCollection {
  public StatusValue HP_Value;
  public StatusValue Attack_Value;
  public StatusValue Defense_Value;
  public StatusValue SpecialAttack_Value;
  public StatusValue SpecialDefense_Value;
  public StatusValue Speed_Value;
}
