unlockedMorphsAt: aPoint
	"Return a collection of all unlocked morphs in this morph structure that contain the given point, possibly including the receiver itself.  Simplified "

	^ self unlockedMorphsAt: aPoint addTo: OrderedCollection new