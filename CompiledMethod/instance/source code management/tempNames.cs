tempNames
	| byteCount bytes |
	byteCount _ self at: self size.
	byteCount = 0 ifTrue: [^ Array new].
	bytes _ (ByteArray new: byteCount)
		replaceFrom: 1 to: byteCount with: self 
		startingAt: self size - byteCount.
	^ (self qDecompress: bytes) findTokens: ' '