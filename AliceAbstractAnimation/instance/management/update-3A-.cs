update: currentTime
	"Updates the animation using the current Wonderland time"

	| newState |

	(state = Waiting) ifTrue: [self prologue: currentTime].

	(state = Running) ifTrue: [
				proportionDone _ styleFunction value: (currentTime - startTime) value: duration.
				newState _ startState interpolateTo: endState at: proportionDone.
				updateFunction value: newState.
				(currentTime >= endTime) ifTrue: [ state _ Finished. ].
							  ].

	(state = Finished) ifTrue: [self epilogue: currentTime].