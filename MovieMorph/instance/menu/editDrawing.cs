editDrawing
	| frame |
	frame _ self currentFrame.
	frame ~~ nil ifTrue: [frame editDrawingIn: self pasteUpMorph forBackground: false]