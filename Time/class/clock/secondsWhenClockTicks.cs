secondsWhenClockTicks

	"waits for the moment when a new second begins"

	| lastSecond delay |

	delay :=  Delay forMilliseconds: 1.
	lastSecond _ self primSecondsClock.
	[ lastSecond = self primSecondsClock ] whileTrue: [ delay wait ].
 
	^ lastSecond + 1