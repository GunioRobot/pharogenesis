pickColorAt: aPoint

	| worldBox globalP c |
	(FeedbackBox containsPoint: aPoint - self topLeft) ifTrue: [^ self].  "do nothing"

	"pick up color, either inside or outside this world"
	worldBox _ self world viewBox.
	globalP _ aPoint + worldBox topLeft.  "get point in screen coordinates"
	(worldBox containsPoint: globalP)
		ifTrue: [c _ self world colorAt: aPoint belowMorph: Morph new]
		ifFalse: [c _ Display colorAt: globalP].

	"check for transparent color and update using appropriate feedback color"
	(TransparentBox containsPoint: aPoint - self topLeft)
		ifTrue: [self updateColor: Color transparent feedbackColor: Color white]
		ifFalse: [self updateColor: c feedbackColor: c].
