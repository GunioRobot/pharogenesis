isLooping
	"Returns true if the animation is looping"

	^ ( loopCount > 1) or: [ loopCount = Infinity ].
