currentColor: aColor
	"Force me to select the closest color to this"

	self invalidRect: (self rectFromIndex: current).
	current _ Color transparent = aColor 
		ifFalse: [(aColor pixelValueForDepth: 8) + 1]
		ifTrue: [1].
	onVector at: current put: true.
	self invalidRect: (self rectFromIndex: current).
