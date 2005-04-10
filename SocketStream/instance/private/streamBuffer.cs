streamBuffer
	^(self isBinary
		ifTrue: [ByteArray]
		ifFalse: [ByteString]) new: self bufferSize