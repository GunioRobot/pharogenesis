pseudoDraw: aRectangle on: aCanvas
	| c f |
	c _ aCanvas copyClipRect: aRectangle.
	f _ self fillStyle.
	f isTranslucent ifTrue: [c fillColor: Color black].
	c fillRectangle: bounds fillStyle: f.
	turtleTrailsForm ifNotNil: [c paintImage: turtleTrailsForm at: 0@0].
	^c