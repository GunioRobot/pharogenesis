OLDrgbDiff: sourceWord with: destinationWord
	"Subract the pixels in the source and destination
	and return the number of differing pixels.
	Note that the region is not clipped to bit boundaries, but only to the
	nearest (enclosing) word.  This is because copyLoop does not do
	pre-merge masking.  For accurate results, you must subtract the
	values obtained from the left and right fringes."
	| diff pixMask |
	self inline: false.
	diff _ sourceWord bitXor: destinationWord.
	pixMask _ maskTable at: pixelDepth.
	[diff = 0] whileFalse:
		[(diff bitAnd: pixMask) ~= 0 ifTrue: [bitCount _ bitCount + 1].
		diff _ diff >> pixelDepth].
	^ destinationWord "for no effect".