nextMessage
	"Select the next message."

	| index |
	mailDB ifNil: [ ^self ].
	currentMsgID isNil ifTrue: [^ self].
	index _ self tocIndex.
	index < currentMessages size
		ifTrue: [self setTOCIndex: index+1 ]
		ifFalse: [self setTOCIndex: 1 ]