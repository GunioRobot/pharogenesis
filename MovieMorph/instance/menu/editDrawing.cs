editDrawing

	| frame |
	frame _ self currentFrame.
	frame ~~ nil ifTrue: [frame editDrawingInWorld: self world].
