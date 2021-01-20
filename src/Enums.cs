namespace Hob_BRB_Player
{
    public enum ApplicationState
    {
        Undefined,
        InitialSetup,
        Idle,
        PlayerActive,
        Exiting
    };

    public enum InitialSetupState
    {
        Undefined,
        Welcome, // 35 %
        BRBDirectory, // 15 %
        // UnknownBRBImport, // 60 %
        PlayerAndChapter, // 25 %
        OBSSetup, // 25 %
        SavingConfig // 0 %
    };

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

    public enum BRBPlaylistSortingMode
    {
        LongToShort,
        ShortToLong,
        Interwoven,
        Random
    };
}