readFromOldFile: file
	"Read a Form in the original ST-80 format"
	| newForm w h code theBits pos offsetX offsetY |
	w _ file nextWord.
	h _ file nextWord.
	offsetX  _ file nextWord.
	offsetY _ file nextWord.
	offsetX > 32767 ifTrue: [offsetX _ offsetX - 65536].
	offsetY > 32767 ifTrue: [offsetY _ offsetY - 65536].
	newForm _ Form extent: w @ h offset: offsetX @ offsetY.
	theBits _ newForm bits.
	pos _ 0.
self halt.  "Update this to 32-bit bitmaps"
	1 to: w + 15 // 16 do:
		[:j | 
		1 to: h do:
			[:i | theBits at: (pos _ pos+1) put: file nextWord]].
	newForm bits: theBits.
	file close.
	^ newForm