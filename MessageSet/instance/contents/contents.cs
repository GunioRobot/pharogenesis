contents
	"Answer the contents of the receiver"

	^ contents == nil
		ifTrue: [currentCompiledMethod _ nil. '']
		ifFalse: [messageListIndex = 0 
			ifTrue: [currentCompiledMethod _ nil. contents]
			ifFalse: [self showingByteCodes
				ifTrue: [self selectedBytecodes]
				ifFalse: [self selectedMessage]]]