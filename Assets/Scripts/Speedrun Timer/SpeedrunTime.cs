using System;
public struct SpeedrunTime
{
    public int minutes;
    public int seconds;
    public int milliSeconds;

    public SpeedrunTime(float totalSeconds)
    {
        //Calculate milliSeconds:
        float milliSecondsDecimal = totalSeconds - (float)Math.Truncate(totalSeconds);
        this.milliSeconds = (int)Math.Round(milliSecondsDecimal * 100f);

        //Calculate seconds:
        int minutesQuotient = (int)Math.Truncate(totalSeconds / 60f);
        this.seconds = (int)Math.Truncate(totalSeconds) - 60 * minutesQuotient;

        //Calculate minutes:
        this.minutes = (int)Math.Truncate(totalSeconds/60f);
    }
}
