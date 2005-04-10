streamBuffer: size
	^(self isBinary
		ifTrue: [ByteArray]
		ifFalse: [ByteString]) new: size