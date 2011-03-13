computeBoundingBox 
	"Refer to the comment in DisplayObject|computeBoundingBox."

	| box |
	box := Rectangle origin: (self at: 1) extent: 0 @ 0.
	collectionOfPoints do: 
		[:aPoint | box := box merge: (Rectangle origin: aPoint extent: 0 @ 0)].
	^box