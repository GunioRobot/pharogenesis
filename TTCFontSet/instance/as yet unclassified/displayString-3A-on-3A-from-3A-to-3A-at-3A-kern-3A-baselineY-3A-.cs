displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY

	| destPoint font form encoding glyphInfo char charCode destY |
	destPoint _ aPoint.
	glyphInfo _ Array new: 5.
	startIndex to: stopIndex do: [:charIndex |
		char _ aString at: charIndex.
		encoding _ char leadingChar + 1.
		charCode _ char charCode.
		font _ fontArray at: encoding.
		((charCode between: font minAscii and: font maxAscii) not) ifTrue: [
			charCode _ font maxAscii].
		self glyphInfoOf: char into: glyphInfo.
		form _ glyphInfo first.
		(glyphInfo fifth ~= aBitBlt lastFont) ifTrue: [
			glyphInfo fifth installOn: aBitBlt.
		].
		destY _ baselineY - glyphInfo fourth. 
		aBitBlt sourceForm: form.
		aBitBlt destX: destPoint x.
		aBitBlt destY: destY.
		aBitBlt sourceOrigin: 0 @ 0.
		aBitBlt width: form width.
		aBitBlt height: form height.
		aBitBlt copyBits.
		destPoint _ destPoint + (form width + kernDelta @ 0).
	].
	^ destPoint.
