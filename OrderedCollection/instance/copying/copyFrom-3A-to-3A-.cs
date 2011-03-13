copyFrom: startIndex to: endIndex 
	"Answer a copy of the receiver that contains elements from position
	startIndex to endIndex. "
	
	"cannot call shallowCopy because shallowCopy calls copyFrom:to:"
	^self basicShallowCopy postCopyFrom: startIndex to: endIndex 