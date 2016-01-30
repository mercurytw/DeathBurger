namespace Team {

    public enum TeamEnum
    {
        kUnaligned = -1,
        kPlayer = 0,
        kEnemy = 1
    }

    public interface ITeamAligned
    {
        TeamEnum getAlignment();
    }

}


