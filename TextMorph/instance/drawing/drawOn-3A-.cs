drawOn: aCanvas
	self setDefaultContentsIfNil.
	"self drawBoundsOn: aCanvas."  "show line rects for debugging"
	self startingIndex > text size
		ifTrue: [self drawNullTextOn: aCanvas]
		ifFalse: [aCanvas paragraph: self paragraph bounds: bounds color: color].
