morphsAt: aPoint
	"Return a collection of all morphs in this morph structure that contain the given point, possibly including the receiver itself.  Simplified "

	^ self morphsAt: aPoint addTo: OrderedCollection new