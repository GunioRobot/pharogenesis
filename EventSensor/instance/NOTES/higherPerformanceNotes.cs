higherPerformanceNotes

"
This is mostly a Mac issue, but may have some effect on other platforms. These changes do not take effect until you set the preference #higherPerformance to true. The impact of setting this pref to true may be higher performance for this Squeak image, but lower performance for other applications/processes that may be running concurrently. Experiment with your particular configuration/desires and decide for yourself.

1. In order to reduce the amount of time lost (perhaps 20 to 30% in some cases) to background applications on the Mac, change the strategy used to poll for UI events. Every time we poll the OS for UI events, increase the delay until the next check. Every time Squeak actually requests an event from EventSensor, reset the delay to its normal value (20 ms). This means that a long-running evaluation started in the UI process will receive less competition from background apps (and less overhead even if it is the only app), but normal UI-intensive operations will happen as they do now. What is lost by this change is some sensitivity to mouse events that occur while Squeak is busy over long periods. My thought is that if Squeak is so occupied for a period of seconds, these events are much less useful and perhaps even harmful.

2. Reduce the minimum morphic cycle time (MinCycleLapse) so that the frame rate (and, hence, running of #step methods) can proceed at greater than 50 frames per second. This can be quite beneficial to things like simulations that are run via #step.
"