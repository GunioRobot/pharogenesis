stepToNextLineIn: line at: yValue
	"Incrementally step to the next scan line in the given line"
	| x  err |
	self inline: true.
	x _ (self edgeXValueOf: line) + (self lineXIncrementOf: line).
	err _ (self lineErrorOf: line) + (self lineErrorAdjUpOf: line).
	err > 0 ifTrue:[
		x _ x + (self lineXDirectionOf: line).
		err _ err - (self lineErrorAdjDownOf: line).
	].
	self lineErrorOf: line put: err.
	self edgeXValueOf: line put: x.