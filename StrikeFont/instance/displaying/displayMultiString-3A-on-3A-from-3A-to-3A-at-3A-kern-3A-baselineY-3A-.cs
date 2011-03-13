displayMultiString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY 
	| destPoint leftX rightX glyphInfo char displayInfo destY |
	destPoint := aPoint.
	charIndex := startIndex.
	glyphInfo := Array new: 5.
	[ charIndex <= stopIndex ] whileTrue: 
		[ char := aString at: charIndex.
		(self hasGlyphOf: char) not 
			ifTrue: 
				[ displayInfo := self fallbackFont 
					displayString: aString
					on: aBitBlt
					from: charIndex
					to: stopIndex
					at: destPoint
					kern: kernDelta
					from: self
					baselineY: baselineY.
				charIndex := displayInfo at: 1.
				destPoint := displayInfo at: 2 ]
			ifFalse: 
				[ self 
					glyphInfoOf: char
					into: glyphInfo.
				leftX := glyphInfo at: 2.
				rightX := glyphInfo at: 3.
				glyphInfo fifth ~= aBitBlt lastFont ifTrue: [ glyphInfo fifth installOn: aBitBlt ].
				aBitBlt sourceForm: (glyphInfo at: 1).
				destY := baselineY - (glyphInfo at: 4).
				aBitBlt destX: destPoint x.
				aBitBlt destY: destY.
				aBitBlt sourceOrigin: leftX @ 0.
				aBitBlt width: rightX - leftX.
				aBitBlt height: self height.
				aBitBlt copyBits.
				destPoint := destPoint + ((rightX - leftX + kernDelta) @ 0).
				charIndex := charIndex + 1 ] ].
	^ Array 
		with: charIndex
		with: destPoint