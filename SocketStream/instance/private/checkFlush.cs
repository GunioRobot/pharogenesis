checkFlush
	self buffered
		ifTrue: [self autoFlush
			ifTrue: [self outStream position > self bufferSize
				ifTrue: [self flush]]]
		ifFalse: [self flush]