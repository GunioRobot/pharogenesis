signal: aSemaphore atTime: signalTime 
	"Signal aSemaphore when the system's millisecond clock reaches 
	the given time (an Integer)."

	^self signal: aSemaphore atMilliseconds: signalTime