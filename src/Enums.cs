namespace Hob_BRB_Player
{
    public enum BRBPlayerState
    {
        Undefined,
        BeginningOfBreak,
        Playback,
        InBetweenBRBs,
        EndOfBreak,
        HobbVLC,
        Exiting,
        ErrorOccurred
    };

    public enum ApplicationState
    {
        Undefined,
        InitialSetup,
        Idle,
        PlayerActive,
        Exiting
    };

    public enum BRBPlaylistSortingMode
    {
        LongToShort,
        ShortToLong,
        Interwoven,
        Random
    };
}