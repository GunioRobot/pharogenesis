displayMultiString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY

	| destPoint leftX rightX glyphInfo char displayInfo destY |
	destPoint _ aPoint.
	charIndex _ startIndex.
	glyphInfo _ Array new: 5.
	[charIndex <= stopIndex] whileTrue: [
		char _ aString at: charIndex.
		(self hasGlyphOf: char) not ifTrue: [
				displayInfo _ self fallbackFont displayString: aString on: aBitBlt from: charIndex to: stopIndex at: destPoint kern: kernDelta from: self baselineY: baselineY.
				charIndex _ displayInfo first.
				destPoint _ displayInfo second.
		] ifFalse: [
			self glyphInfoOf: char into: glyphInfo.
			leftX _ glyphInfo second.
			rightX _ glyphInfo third.
			(glyphInfo fifth ~= aBitBlt lastFont) ifTrue: [
				glyphInfo fifth installOn: aBitBlt.
			].
			aBitBlt sourceForm: glyphInfo first.
			destY _ baselineY - glyphInfo fourth. 
			aBitBlt destX: destPoint x.
			aBitBlt destY: destY.
			aBitBlt sourceOrigin: leftX @ 0.
			aBitBlt width: rightX - leftX.
			aBitBlt height: self height.
			aBitBlt copyBits.
			destPoint _ destPoint + (rightX - leftX + kernDelta @ 0).
			charIndex _ charIndex + 1.
		].
	].
	^ Array with: charIndex with: destPoint.
