streamBuffer
self flag: #ByteString.
	^(self isBinary
		ifTrue: [String]
		ifFalse: [ByteArray]) new: self bufferSize