contents
	^ contents == nil
		ifTrue: [currentCompiledMethod _ nil. '']
		ifFalse: [messageListIndex = 0 
			ifTrue: [currentCompiledMethod _ nil. contents]
			ifFalse: [editSelection == #byteCodes
				ifTrue: [(self selectedClassOrMetaClass
							compiledMethodAt: self selectedMessageName) symbolic]
				ifFalse: [self selectedMessage]]]