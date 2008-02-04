displayStringR2L: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta 

	| destPoint font |
	destPoint := aPoint.
	startIndex to: stopIndex do: [:charIndex | 
		| encoding ascii xTable leftX rightX | 
		encoding := (aString at: charIndex) leadingChar + 1.
		ascii := (aString at: charIndex) charCode.
		font := fontArray at: encoding.
		((ascii between: font minAscii and: font maxAscii) not) ifTrue: [
			ascii := font maxAscii].
		xTable := font xTable.
		leftX := xTable at: ascii + 1.
		rightX := xTable at: ascii + 2.
		aBitBlt sourceForm: font glyphs.
		aBitBlt destX: destPoint x - (rightX - leftX).
		aBitBlt destY: destPoint y.
		aBitBlt sourceOrigin: leftX @ 0.
		aBitBlt width: rightX - leftX.
		aBitBlt height: self height.
		aBitBlt copyBits.
		destPoint := destPoint - (rightX - leftX + kernDelta @ 0).
	].
