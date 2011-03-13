inBufNext: anInteger
	
	| answer |
	answer _ inBuf copyFrom: inBufIndex to: inBufIndex + anInteger - 1.
	inBufIndex _ inBufIndex + anInteger.
	^answer