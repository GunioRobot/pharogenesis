displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY

	| destPoint leftX rightX glyphInfo g destY |
	destPoint _ aPoint.
	glyphInfo _ Array new: 5.
	startIndex to: stopIndex do: [:charIndex |
		self glyphInfoOf: (aString at: charIndex) into: glyphInfo.
		g _ glyphInfo first.
		leftX _ glyphInfo second.
		rightX _ glyphInfo third.
		(glyphInfo fifth ~= aBitBlt lastFont) ifTrue: [
			glyphInfo fifth installOn: aBitBlt.
		].
		aBitBlt sourceForm: g.
		destY _ baselineY - glyphInfo fourth. 
		aBitBlt destX: destPoint x.
		aBitBlt destY: destY.
		aBitBlt sourceOrigin: leftX @ 0.
		aBitBlt width: rightX - leftX.
		aBitBlt height: self height.
		aBitBlt copyBits.
		destPoint _ destPoint + (rightX - leftX + kernDelta @ 0).
	].
	^ destPoint.

