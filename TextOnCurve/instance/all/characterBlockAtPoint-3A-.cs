characterBlockAtPoint: aPoint 
	"Answer a CharacterBlock for the character in the text at aPoint."
	| sourcePoint cb curvePoint |
	self textSegmentsDo:
		[:line :destRect :segStart :segAngle |
		(destRect containsPoint: aPoint) ifTrue:
			["It's in the destRect; now convert to source coords"
			sourcePoint _ self pointInLine: line forDestPoint: aPoint
							segStart: segStart segAngle: segAngle.
			cb _ (CharacterBlockScanner new text: text textStyle: textStyle)
				characterBlockAtPoint: (sourcePoint adhereTo: line rectangle)
				index: nil in: line.
			(sourcePoint x between: line left and: line right) ifTrue:
				["Definitely in this segment"
				^ cb]]].
	"Point is off curve -- try again with closest point on curve"
	curvePoint _ curve closestPointTo: aPoint.
	curvePoint = aPoint ifFalse:
		[^ self characterBlockAtPoint: curvePoint].
	"If all else fails, at least return something acceptable."
	^ cb ifNil: [self defaultCharacterBlock]