showBytecodes
	"Show or hide the bytecodes of the selected method."

	(messageListIndex = 0 or: [self okToChange not])
		ifTrue: [^ self changed: #flash].
	editSelection == #byteCodes
		ifTrue: [editSelection _ #editMessage]
		ifFalse: [editSelection _ #byteCodes].
	self contentsChanged