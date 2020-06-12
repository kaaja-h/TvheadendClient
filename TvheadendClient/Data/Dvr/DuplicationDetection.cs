namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Duplicity detection
    /// </summary>
    public enum DuplicityDetection
    {

        /// <summary>
        /// Record All
        /// </summary>
        All = 0,

        /// <summary>
        /// All: Record if EPG/XMLTV indicates it is a unique programme
        /// </summary>
        UniqueGlobal = 14,

        /// <summary>
        /// All: Record if different episode number
        /// </summary>
        DifferentEpisodeNumberGlobal = 1,

        /// <summary>
        /// All: Record if different subtitle
        /// </summary>
        DifferentSubtitleGlobal = 2,

        /// <summary>
        /// All: Record if different description
        /// </summary>
        DifferentDescriptionGlobal = 3,

        /// <summary>
        /// All: Record once per month
        /// </summary>
        RecordOncePerMonthGlobal = 12,

        /// <summary>
        /// All: Record once per week
        /// </summary>
        RecordOncePerWeekGlobal = 4,

        /// <summary>
        /// All: Record once per day
        /// </summary>
        RecordOncePerDayGlobal = 5,

        /// <summary>
        /// Local: Record if different episode number
        /// </summary>
        DifferentEpisodeNumberLocal = 6,

        /// <summary>
        /// Local: Record if different title
        /// </summary>
        DifferentTitleLocal = 7,

        /// <summary>
        /// Local: Record if different subtitle
        /// </summary>
        DifferentSubtitleLocal = 8,

        /// <summary>
        /// Local: Record if different description
        /// </summary>
        DifferentDescriptionLocal = 9,

        /// <summary>
        /// Local: Record once per month
        /// </summary>
        RecordOncePerMonthLocal = 13,

        /// <summary>
        /// Local: Record once per week
        /// </summary>
        RecordOncePerWeekLocal = 10,

        /// <summary>
        /// Local: Record once per day
        /// </summary>
        RecordOncePerDayLocal = 11,



    }
}