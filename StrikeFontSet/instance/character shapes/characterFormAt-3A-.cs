characterFormAt: character 

	| encoding ascii xTable leftX rightX |
	encoding _ character leadingChar + 1.
	ascii _ character charCode.
	(ascii < (fontArray at: encoding) minAscii or: [ascii > (fontArray at: encoding) maxAscii])
		ifTrue: [ascii _ (fontArray at: encoding) maxAscii].
	xTable _ (fontArray at: encoding) xTable.
	leftX _ xTable at: ascii + 1.
	rightX _ xTable at: ascii + 2.
	^ (fontArray at: encoding) glyphs copy: (leftX @ 0 corner: rightX @ self height).
