loop
	"This method causes an animation to loop forever."

	loopCount _ Infinity.

	(state = Stopped) ifTrue: [ state _ Waiting.
							  myScheduler addAnimation: self. ].
