drawOnTest: aCanvas
	"Draw the receiver on a canvas"

	| fauxBounds |
	self setDefaultContentsIfNil.
	super drawOn: aCanvas.  "Border and background if any"
	false ifTrue: [self debugDrawLineRectsOn: aCanvas].  "show line rects for debugging"
	(self startingIndex > text size)
		ifTrue: [self drawNullTextOn: aCanvas].
	"Hack here:  The canvas expects bounds to carry the location of the text, but we also need to communicate clipping."
	fauxBounds _ self bounds topLeft corner: self innerBounds bottomRight.
	aCanvas paragraph3: self paragraph bounds: fauxBounds color: color