move: aDirection distance: aDistance
	"Move the morph the specified distance in the specified direction"

	^ self move: aDirection distance: aDistance duration: 1.0 style: gently.
