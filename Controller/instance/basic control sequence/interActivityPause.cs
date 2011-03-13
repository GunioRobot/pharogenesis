interActivityPause
	"if we are looping quickly, insert a short delay.  Thus if we are just doing UI stuff, we won't take up much CPU"
	| currentTime wait |
	MinActivityLapse ifNotNil: [
		lastActivityTime ifNotNil: [ 
			currentTime := Time millisecondClockValue.
			wait := lastActivityTime + MinActivityLapse - currentTime.
			wait > 0 ifTrue: [ 
				wait <= MinActivityLapse  "big waits happen after a snapshot"
					ifTrue: [DisplayScreen checkForNewScreenSize.
							(Delay forMilliseconds: wait) wait ]. ]. ]. ].

	lastActivityTime := Time millisecondClockValue.