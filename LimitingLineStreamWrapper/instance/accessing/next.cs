next
	"Provide character-based access"

	position isNil ifTrue: [^nil].
	position < line size ifTrue: [^line at: (position _ position + 1)].
	line _ stream nextLine.
	self updatePosition.
	^ Character cr