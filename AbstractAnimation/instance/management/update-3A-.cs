update: currentTime
	"Updates the animation using the current Wonderland time"

	(state = Waiting) ifTrue: [self prologue: currentTime].

	(state = Running) ifTrue: [].

	(state = Finished) ifTrue: [self epilogue: currentTime].
