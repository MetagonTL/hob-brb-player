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
        Welcome, // 15 %
        BRBDirectory, // 5 %
        UnknownBRBImport, // 60 %
        PlayerAndChapter, // 10 %
        OBSSetup, // 10 %
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