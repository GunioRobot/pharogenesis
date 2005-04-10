streamBuffer: size
self flag: #ByteString.
	^(self isBinary
		ifTrue: [ByteArray]
		ifFalse: [String]) new: size