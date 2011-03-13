tempNames

	| byteCount bytes |
	self holdsTempNames ifFalse: [
		^ (1 to: self numTemps) collect: [:i | 't', i printString]
	].
	byteCount := self at: self size.
	byteCount = 0 ifTrue: [^ Array new].
	bytes := (ByteArray new: byteCount)
		replaceFrom: 1 to: byteCount with: self 
		startingAt: self size - byteCount.
	^ (self qDecompress: bytes) findTokens: ' '