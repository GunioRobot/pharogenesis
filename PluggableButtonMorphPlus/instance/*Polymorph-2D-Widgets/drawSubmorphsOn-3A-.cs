drawSubmorphsOn: aCanvas 
	"Display submorphs back to front.
	Whiten the whole thing if disabled."

	super drawSubmorphsOn: aCanvas.
	(self enabled not and: [self label isMorph and: [(self label respondsTo: #enabled:) not]])
		ifTrue: [aCanvas fillRectangle: self submorphBounds fillStyle: (Color white alpha: 0.5)]