streamBuffer: size
	^(self isBinary
		ifTrue: [ByteArray]
		ifFalse: [String]) new: size