copyBitsFrom: startX to: stopX at: yValue
	"Support for the balloon engine."
	self export: true.
	destX _ startX.
	destY _ yValue.
	sourceX _ startX.
	width _ (stopX - startX).
	self copyBits.
	self showDisplayBits.