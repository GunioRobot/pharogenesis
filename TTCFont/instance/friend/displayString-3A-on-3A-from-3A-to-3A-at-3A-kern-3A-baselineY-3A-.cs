displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY

	| destPoint form glyphInfo destY |
	destPoint _ aPoint.
	glyphInfo _ Array new: 5.
	startIndex to: stopIndex do: [:charIndex |
		self glyphInfoOf: (aString at: charIndex) into: glyphInfo.
		form _ glyphInfo first.
		(glyphInfo fifth ~= aBitBlt lastFont) ifTrue: [
			glyphInfo fifth installOn: aBitBlt.
		].
		destY _ baselineY - glyphInfo fourth. 
		aBitBlt sourceForm: form.
		aBitBlt destX: destPoint x.
		aBitBlt destY: destY.
		aBitBlt sourceOrigin: (glyphInfo second) @ 0.
		aBitBlt width: glyphInfo third - glyphInfo second.
		aBitBlt height: form height.
		aBitBlt copyBits.
		destPoint _ destPoint + ((glyphInfo third - glyphInfo second) + kernDelta @ 0).
	].
	^ destPoint.
