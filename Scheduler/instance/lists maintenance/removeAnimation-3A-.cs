removeAnimation: anAnimation
	"Remove an animation from the Scheduler's list of animations"

	animationList remove: anAnimation ifAbsent: [].
