updateTogether: currentTime
	"Update this script assuming that all script commands begin simultaneously"

	activeAnimations do: [:anim | anim update: currentTime.
								(anim isDone) ifTrue: [activeAnimations remove: anim ]].

	(activeAnimations isEmpty) ifTrue: [ isRunning _ false ].


