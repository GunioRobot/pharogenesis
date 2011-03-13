strikeFromHex: file width: w height: h
	"read in just the raw strike bits from a hex file.  No spaces or returns.  W is in words (2 bytes), h in pixels." 
	| newForm theBits offsetX offsetY str num cnt |
	offsetX  _ 0.
	offsetY _ 0.
	offsetX > 32767 ifTrue: [offsetX _ offsetX - 65536]. "stored two's-complement"
	offsetY > 32767 ifTrue: [offsetY _ offsetY - 65536]. "stored two's-complement"
	newForm _ Form extent: strikeLength @ h offset: offsetX @ offsetY.
	theBits _ newForm bits.
	cnt _ 0.		"raster may be 16 bits, but theBits width is 32" 
	1 to: theBits size do: [:i | 
		(cnt _ cnt + 32) > strikeLength 
		  ifTrue: [cnt _ 0.
			num _ Number readFrom: (str _ file next: 4) base: 16]
		  ifFalse: [
			cnt = strikeLength ifTrue: [cnt _ 0].
			num _ Number readFrom: (str _ file next: 8) base: 16].
		theBits at: i put: num].
	glyphs _ newForm.