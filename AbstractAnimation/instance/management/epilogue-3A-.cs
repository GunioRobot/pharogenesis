epilogue: currentTime
	"This method does any work that needs to be done after an interation of the animation finishes."

	(loopCount = Infinity) ifTrue:
				[state _ Waiting]
	ifFalse:
				[
					loopCount _ loopCount - 1.

					(loopCount > 0) ifTrue: [ state _ Waiting ]
									ifFalse: [state _ Stopped.
											 loopCount _ 1 ].
				].

