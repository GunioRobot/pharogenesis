streamBuffer
	^(self isBinary
		ifTrue: [String]
		ifFalse: [ByteArray]) new: self bufferSize