rgbDiff: sourceWord with: destinationWord
	"Subract the pixels in the source and destination
	and return the number of differing pixels."
	| pixMask destShifted sourceShifted destPixVal sourcePixVal maskShifted |
	self inline: false.
	pixMask _ maskTable at: pixelDepth.
	maskShifted _ destMask.
	destShifted _ destinationWord.
	sourceShifted _ sourceWord.
	1 to: destPPW do:
		[:i |
		(maskShifted bitAnd: pixMask) > 0 ifTrue:
			["Only tally pixels within the destination rectangle"
			destPixVal _ destShifted bitAnd: pixMask.
			sourcePixVal _ sourceShifted bitAnd: pixMask.
			sourcePixVal = destPixVal ifFalse: [bitCount _ bitCount + 1]].
		maskShifted _ maskShifted >> pixelDepth.
		sourceShifted _ sourceShifted >> pixelDepth.
		destShifted _ destShifted >> pixelDepth].
	^ destinationWord  "For no effect on dest"
