interCyclePause: milliSecs
	"delay enough that the next interaction cycle won't happen too soon after the original; thus, if all the system is doing is polling for interaction, the overall CPU usage of Squeak will be low"

	| currentTime wait |

	currentTime _ Time millisecondClockValue.
	(lastCycleTime notNil and: [CanSurrenderToOS ~~ false]) ifTrue: [ 
		wait _ lastCycleTime + milliSecs - currentTime.
		wait > 0 ifTrue: [ 
			wait <= milliSecs  "big waits happen after a snapshot"
				ifTrue: [DisplayScreen checkForNewScreenSize.
						(Delay forMilliseconds: wait) wait ]. 
		].
	].
	"record the time AFTER the wait"
	lastCycleTime _  Time millisecondClockValue.
	CanSurrenderToOS _ true.