displayStringR2L: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta 

	| destPoint font form encoding char charCode glyphInfo |
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
			(glyphInfo size > 4 and: [glyphInfo fifth notNil and: [glyphInfo fifth ~= aBitBlt lastFont]]) ifTrue: [
				glyphInfo fifth installOn: aBitBlt.
			].
		aBitBlt sourceForm: form.
		aBitBlt destX: destPoint x - form width.
		aBitBlt destY: destPoint y.
		aBitBlt sourceOrigin: 0 @ 0.
		aBitBlt width: form width.
		aBitBlt height: form height.
		aBitBlt copyBits.
		destPoint _ destPoint - (form width + kernDelta @ 0).
	].
