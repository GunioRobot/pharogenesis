setBounds: aRectangle for: anActor
	"Record the 2D bounds for the given actor during a rendering pass"
	aRectangle == nil ifFalse:[bounds at: anActor put: (aRectangle intersect: myMorph bounds)].