tocEntry
	"Answer the table of contents entry for the currently selected message or nil."

	(currentMsgID isNil)
		ifTrue: [^nil]
		ifFalse: [^currentTOC at: (currentMessages indexOf: currentMsgID)].
