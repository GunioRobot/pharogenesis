rgbDiff: sourceWord with: destinationWord
	"Subract the pixels in the source and destination, color by color,
	and return the sum of the absolute value of all the differences.
	For non-rgb, return the number of differing pixels."
	| pixMask destShifted sourceShifted destPixVal bitsPerColor rgbMask sourcePixVal diff maskShifted |
	self inline: false.
	pixMask _ maskTable at: destDepth.
	destDepth = 16
		ifTrue: [bitsPerColor _ 5.  rgbMask _ 16r1F]
		ifFalse: [bitsPerColor _ 8.  rgbMask _ 16rFF].
	maskShifted _ destMask.
	destShifted _ destinationWord.
	sourceShifted _ sourceWord.
	1 to: destPPW do:
		[:i |
		(maskShifted bitAnd: pixMask) > 0 ifTrue:
			["Only tally pixels within the destination rectangle"
			destPixVal _ destShifted bitAnd: pixMask.
			sourcePixVal _ sourceShifted bitAnd: pixMask.
			destDepth < 16
				ifTrue: [sourcePixVal = destPixVal
							ifTrue: [diff _ 0]
							ifFalse: [diff _ 1]]
				ifFalse: [diff _ (self partitionedSub: sourcePixVal from: destPixVal
								nBits: bitsPerColor nPartitions: 3).
						diff _ (diff bitAnd: rgbMask)
							+ (diff>>bitsPerColor bitAnd: rgbMask)
							+ ((diff>>bitsPerColor)>>bitsPerColor bitAnd: rgbMask)].
			bitCount _ bitCount + diff].
		maskShifted _ maskShifted >> destDepth.
		sourceShifted _ sourceShifted >> destDepth.
		destShifted _ destShifted >> destDepth].
	^ destinationWord  "For no effect on dest"
