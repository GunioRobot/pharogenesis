displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta from: fromFont baselineY: baselineY

	| destPoint leftX rightX glyphInfo g tag char destY |
	destPoint _ aPoint.
	rIndex _ startIndex.
	tag _ (aString at: rIndex) leadingChar.
	glyphInfo _ Array new: 5.
	[rIndex <= stopIndex] whileTrue: [
		char _ aString at: rIndex.
		((fromFont hasGlyphOf: char) or: [char leadingChar ~= tag]) ifTrue: [^ Array with: rIndex with: destPoint].
		self glyphInfoOf: char into: glyphInfo.
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
		rIndex _ rIndex + 1.
	].
	^ Array with: rIndex with: destPoint.
