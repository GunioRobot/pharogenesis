getFrame
	"Ask the user to designate a rectangular area in which
	the receiver should be displayed."
	| minFrame |
	minFrame _ Cursor origin showWhile: 
		[(Sensor cursorPoint extent: self minimumSize) newRectFrom:
			[:f | Sensor cursorPoint extent: self minimumSize]].
	self maximumSize <= self minimumSize ifTrue: [^ minFrame].
	^ Cursor corner showWhile:
		[minFrame newRectFrom:
			[:f | self constrainFrame: (f origin corner: Sensor cursorPoint)]]