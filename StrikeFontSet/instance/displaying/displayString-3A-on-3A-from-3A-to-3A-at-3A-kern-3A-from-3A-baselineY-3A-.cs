displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta from: fromFont baselineY: baselineY

	| destPoint leftX rightX glyphInfo g tag char destY |
	destPoint := aPoint.
	rIndex := startIndex.
	tag := (aString at: rIndex) leadingChar.
	glyphInfo := Array new: 5.
	[rIndex <= stopIndex] whileTrue: [
		char := aString at: rIndex.
		((fromFont hasGlyphOf: char) or: [char leadingChar ~= tag]) ifTrue: [^ Array with: rIndex with: destPoint].
		self glyphInfoOf: char into: glyphInfo.
		g := glyphInfo first.
		leftX := glyphInfo second.
		rightX := glyphInfo third.
		(glyphInfo fifth ~= aBitBlt lastFont) ifTrue: [
			glyphInfo fifth installOn: aBitBlt.
		].
		aBitBlt sourceForm: g.
		destY := baselineY - glyphInfo fourth. 
		aBitBlt destX: destPoint x.
		aBitBlt destY: destY.
		aBitBlt sourceOrigin: leftX @ 0.
		aBitBlt width: rightX - leftX.
		aBitBlt height: self height.
		aBitBlt copyBits.
		destPoint := destPoint + (rightX - leftX + kernDelta @ 0).
		rIndex := rIndex + 1.
	].
	^ Array with: rIndex with: destPoint.
