processAnimations
	"This method processes any active Animations and removes any that are completed."

	animationList do: [:anim | anim update: currentTime.
							(anim isDone) ifTrue: [self removeAnimation: anim]
				].
