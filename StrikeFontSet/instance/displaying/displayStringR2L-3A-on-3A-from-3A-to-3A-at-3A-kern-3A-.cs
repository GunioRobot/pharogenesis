displayStringR2L: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta 

	| destPoint font |
	destPoint _ aPoint.
	startIndex to: stopIndex do: [:charIndex | 
		| encoding ascii xTable leftX rightX | 
		encoding _ (aString at: charIndex) leadingChar + 1.
		ascii _ (aString at: charIndex) charCode.
		font _ fontArray at: encoding.
		((ascii between: font minAscii and: font maxAscii) not) ifTrue: [
			ascii _ font maxAscii].
		xTable _ font xTable.
		leftX _ xTable at: ascii + 1.
		rightX _ xTable at: ascii + 2.
		aBitBlt sourceForm: font glyphs.
		aBitBlt destX: destPoint x - (rightX - leftX).
		aBitBlt destY: destPoint y.
		aBitBlt sourceOrigin: leftX @ 0.
		aBitBlt width: rightX - leftX.
		aBitBlt height: self height.
		aBitBlt copyBits.
		destPoint _ destPoint - (rightX - leftX + kernDelta @ 0).
	].
