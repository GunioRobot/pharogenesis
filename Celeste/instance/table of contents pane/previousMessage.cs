previousMessage
	"Select the previous message."

	| index |
	(currentCategory isNil | currentMsgID isNil) ifTrue: [^ self].
	index _ currentMessages indexOf: currentMsgID.
	index > 1
		ifTrue: [self setTOCEntry: (currentTOC  at: index - 1)]
		ifFalse: [self setTOCEntry: (currentTOC  at: currentMessages size)].

