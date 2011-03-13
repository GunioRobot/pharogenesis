addToInBuf: aString

	| newAlloc |
	newAlloc _ aString size * 2 max: 8000.
	inBuf ifNil: [
		inBuf _ String new: newAlloc.
		inBufIndex _ 1.
		inBufLastIndex _ 0.
	].
	aString size > (inBuf size - inBufLastIndex) ifTrue: [
		inBuf _ inBuf , (String new: newAlloc)
	].
	inBuf 
		replaceFrom: inBufLastIndex + 1 
		to: inBufLastIndex + aString size
		with: aString 
		startingAt: 1.
	inBufLastIndex _ inBufLastIndex + aString size.
