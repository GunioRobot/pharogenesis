update: currentTime
	"This method updates the sequential animation based on the current time."

	| child notDone |

	"Do the prologue to this animation"
	(state = Waiting) ifTrue: [self prologue: currentTime].

	"Finish right away if there are no component animations"
	((children size) = 0) ifTrue: [ state _ Finished].

	"Update the current animation segment.  When it finishes, move on to the next non-zero duration animation. If there aren't any more, then the sequential animation is done."
	(state = Running) ifTrue: [
				child _ children at: index.
				child update: currentTime.
				notDone _ (child getState) = Stopped.
				[ notDone ] whileTrue: [
						index _ index + 1.
						(index <= (children size)) ifTrue: [ child _ children at: index.
														  child prologue: currentTime.
														  child update: currentTime.
														  notDone _ (child getState) = Stopped.
														]
												ifFalse: [ state _ Finished.
														  notDone _ false.
														].
											]

							  ].

	"After the animation finishes run the epilogue."
	(state = Finished) ifTrue: [self epilogue: currentTime].
