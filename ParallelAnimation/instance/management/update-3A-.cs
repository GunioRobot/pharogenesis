update: currentTime
	"This method updates the parallel animation based on the current time, which mainly consists of updating all the component animations."

	| index |

	(state = Waiting) ifTrue: [self prologue: currentTime].

	(state = Running) ifTrue: [
			state _ Finished.

			"Update every child.  If any one of them is not Stopped set our state back to Running"

			index _ 1.
			children do: [: child |  ((child getState) = Running) ifTrue: [child update: currentTime].
					((child getState) = Finished) ifTrue: [child epilogue: currentTime].
					((child getState) = Waiting) ifTrue: [child prologue: currentTime].
					((child getState) = Stopped) ifFalse: [state _ Running].

					((direction = Reverse) and: [ ((child getState) = Paused) ]) ifTrue: [
						((currentTime - startTime) >
								(duration - ((child getDuration) * (childLoopCounts at: index))))
									ifTrue: [ child resume ] ].
					index _ index + 1.
						].

							  ].

	(state = Finished) ifTrue: [self epilogue: currentTime].
