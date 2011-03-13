shrinkInBuf

	inBuf ifNil: [^self].
	inBufLastIndex < inBufIndex ifTrue: [
		inBufLastIndex _ 0.
		inBufIndex _ 1.
		inBuf size > 20000 ifTrue: [inBuf _ nil].	"if really big, kill it"
		^self
	].
	inBuf _ inBuf copyFrom: inBufIndex to: inBufLastIndex.
	inBufLastIndex _ inBuf size.
	inBufIndex _ 1.

