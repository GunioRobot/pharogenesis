flattenExample		"StrokeSimplifier flattenExample"
	"This example demonstrate how aggressive the stroke recorder simplifies series of points"
	| pts fc lastPt nextPt |
	[Sensor anyButtonPressed] whileFalse.
	fc _ FormCanvas on: Display.
	pts _ self new.
	lastPt _ Sensor cursorPoint.
	pts add: lastPt.
	[Sensor anyButtonPressed] whileTrue:[
		nextPt _ Sensor cursorPoint.
		nextPt = lastPt ifFalse:[
			fc line: lastPt to: nextPt width: 3 color: Color black.
			pts add: nextPt.
			lastPt _ nextPt.
		].
	].
	pts closeStroke.
	(PolygonMorph vertices: pts finalStroke color: Color transparent borderWidth: 3 borderColor: Color black) makeOpen; addHandles; openInWorld.
