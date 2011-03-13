tocEntry
	"Answer the table of contents entry for the currently selected message  
	or nil."
	currentMsgID isNil
		ifTrue: [^ nil]
		ifFalse: [^ (self tocLists at: 1)
				at: (currentMessages indexOf: currentMsgID)]