displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY

	| destPoint font form encoding glyphInfo char charCode destY |
	destPoint := aPoint.
	glyphInfo := Array new: 5.
	startIndex to: stopIndex do: [:charIndex |
		char := aString at: charIndex.
		encoding := char leadingChar + 1.
		charCode := char charCode.
		font := fontArray at: encoding.
		((charCode between: font minAscii and: font maxAscii) not) ifTrue: [
			charCode := font maxAscii].
		self glyphInfoOf: char into: glyphInfo.
		form := glyphInfo first.
		(glyphInfo fifth ~= aBitBlt lastFont) ifTrue: [
			glyphInfo fifth installOn: aBitBlt.
		].
		destY := baselineY - glyphInfo fourth. 
		aBitBlt sourceForm: form.
		aBitBlt destX: destPoint x.
		aBitBlt destY: destY.
		aBitBlt sourceOrigin: 0 @ 0.
		aBitBlt width: form width.
		aBitBlt height: form height.
		aBitBlt copyBits.
		destPoint := destPoint + (form width + kernDelta @ 0).
	].
	^ destPoint.
