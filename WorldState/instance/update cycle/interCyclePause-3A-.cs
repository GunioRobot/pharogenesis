interCyclePause: milliSecs
	"delay enough that the previous cycle plus the amount of delay will equal milliSecs.  If the cycle is already expensive, then no delay occurs.  However, if the system is idly waiting for interaction from the user, the method will delay for a proportionally long time and cause the overall CPU usage of Squeak to be low."

	| currentTime wait |

	(lastCycleTime notNil and: [CanSurrenderToOS ~~ false]) ifTrue: [ 
		 currentTime _ Time millisecondClockValue.
		  wait _ lastCycleTime + milliSecs - currentTime.
		  (wait > 0 and: [ wait <= milliSecs ] )
		ifTrue: [
			(Delay forMilliseconds: wait) wait ]. 
	].

	lastCycleTime _  Time millisecondClockValue.
	CanSurrenderToOS _ true.