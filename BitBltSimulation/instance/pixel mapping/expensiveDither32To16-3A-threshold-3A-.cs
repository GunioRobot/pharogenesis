expensiveDither32To16: srcWord threshold: ditherValue
	"Dither the given 32bit word to 16 bit. Ignore alpha."
	| pv threshold value out |
	self inline: true. "You bet"
	pv _ srcWord bitAnd: 255.
	threshold _ ditherThresholds16 at: (pv bitAnd: 7).
	value _ ditherValues16 at: (pv bitShift: -3).
	ditherValue < threshold
		ifTrue:[out _ value + 1]
		ifFalse:[out _ value].
	pv _ (srcWord bitShift: -8) bitAnd: 255.
	threshold _ ditherThresholds16 at: (pv bitAnd: 7).
	value _ ditherValues16 at: (pv bitShift: -3).
	ditherValue < threshold
		ifTrue:[out _ out bitOr: (value+1 bitShift:5)]
		ifFalse:[out _ out bitOr: (value bitShift: 5)].
	pv _ (srcWord bitShift: -16) bitAnd: 255.
	threshold _ ditherThresholds16 at: (pv bitAnd: 7).
	value _ ditherValues16 at: (pv bitShift: -3).
	ditherValue < threshold
		ifTrue:[out _ out bitOr: (value+1 bitShift:10)]
		ifFalse:[out _ out bitOr: (value bitShift: 10)].
	^out