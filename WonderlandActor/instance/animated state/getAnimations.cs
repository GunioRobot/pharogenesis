getAnimations
	"Return the animations currently affecting this object"

	^ (myWonderland getScheduler) getAnimationsFor: self.
