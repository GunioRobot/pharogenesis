encodeStringArray: stringArray
	| size outBuf outBufIndex |
	size _ self spaceToEncode: stringArray.
	
	outBuf _ String new: size.
	outBufIndex _ 1.

	outBuf putInteger32: stringArray size at: outBufIndex.
	outBufIndex _ outBufIndex + 4.
	stringArray do: [ :each |
		outBuf putInteger32: each size at: outBufIndex.
		outBufIndex _ outBufIndex + 4.
		outBuf 
			replaceFrom: outBufIndex 
			to: outBufIndex + each size - 1 
			with: each 
			startingAt: 1.
		outBufIndex _ outBufIndex + each size.
	].
	
	^outBuf