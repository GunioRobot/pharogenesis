fillAllFrom: leftX to: rightX
	"Fill the span buffer from leftX to rightX with the given fill."
	| fill startX stopX |
	self inline: true.
	fill _ self topFill.
	startX _ leftX.
	stopX _ self topRightX.
	[stopX < rightX] whileTrue:[
		fill _ self makeUnsignedFrom: self topFill.
		fill = 0 ifFalse:[
			(self fillSpan: fill from: startX to: stopX) ifTrue:[^true]].
		self quickRemoveInvalidFillsAt: stopX.
		startX _ stopX.
		stopX _ self topRightX].
	fill _ self makeUnsignedFrom: self topFill.
	fill = 0 ifFalse:[^self fillSpan: fill from: startX to: rightX].
	^false