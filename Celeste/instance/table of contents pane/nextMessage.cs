nextMessage
	"Select the next message."

	| index |
	(currentCategory isNil | currentMsgID isNil) ifTrue: [^ self].
	index _ currentMessages indexOf: currentMsgID.
	index < currentMessages size
		ifTrue: [self setTOCEntry: (currentTOC at: index + 1)]
		ifFalse: [self setTOCEntry: (currentTOC at: 1)].
