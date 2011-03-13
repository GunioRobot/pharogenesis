addToOutBuf: arrayToWrite

	| size newAlloc |
	size _ self spaceToEncode: arrayToWrite.
	newAlloc _ size * 2 max: 8000.	"gives us room to grow"
	outBuf ifNil: [
		outBuf _ String new: newAlloc.
		outBufIndex _ 1.
	].
	outBuf size - outBufIndex + 1 < size ifTrue: [
		outBuf _ outBuf , (String new: newAlloc).
	].
	CanvasEncoder at: 1 count: arrayToWrite size + 1.
	outBuf putInteger32: arrayToWrite size at: outBufIndex.
	outBufIndex _ outBufIndex + 4.
	arrayToWrite do: [ :each |
		outBuf putInteger32: each size at: outBufIndex.
		outBufIndex _ outBufIndex + 4.
		outBuf 
			replaceFrom: outBufIndex 
			to: outBufIndex + each size - 1 
			with: each 
			startingAt: 1.
		outBufIndex _ outBufIndex + each size.
	].
	^size