loop: numberOfTimes
	"This method causes an animation to loop for the specified number of times."

	loopCount _ numberOfTimes.

	(state = Stopped) ifTrue: [ state _ Waiting.
							  myScheduler addAnimation: self. ].
