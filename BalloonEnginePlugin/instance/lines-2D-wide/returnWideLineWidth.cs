returnWideLineWidth
	"Return the width of the (wide) line - this method is called from a case."
	^(dispatchReturnValue _ self wideLineWidthOf: dispatchedValue).