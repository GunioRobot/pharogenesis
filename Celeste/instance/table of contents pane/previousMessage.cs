previousMessage
	"Select the previous message."

	| index |
	mailDB ifNil: [ ^self ].
	currentMsgID isNil ifTrue: [^ self].
	index _ self tocIndex.
	index > 1
		ifTrue: [self setTOCIndex: index-1 ]
		ifFalse: [self setTOCIndex: currentMessages size ]