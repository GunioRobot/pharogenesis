readFromOldFormat: aBinaryStream
	"Read a Form in the original ST-80 format."

	| w h offsetX offsetY newForm theBits pos |
	self error: 'this method must be updated to read into 32-bit word bitmaps'.
	w _ aBinaryStream nextWord.
	h _ aBinaryStream nextWord.
	offsetX  _ aBinaryStream nextWord.
	offsetY _ aBinaryStream nextWord.
	offsetX > 32767 ifTrue: [offsetX _ offsetX - 65536].
	offsetY > 32767 ifTrue: [offsetY _ offsetY - 65536].
	newForm _ Form extent: w @ h offset: offsetX @ offsetY.
	theBits _ newForm bits.
	pos _ 0.
	1 to: w + 15 // 16 do: [:j |
		1 to: h do: [:i |
			theBits at: (pos _ pos+1) put: aBinaryStream nextWord]].
	newForm bits: theBits.
	^ newForm
