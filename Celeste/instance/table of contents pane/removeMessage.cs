removeMessage
	"Remove the current message from the current category."
	| currentMessageIndex |
	currentMsgID
		ifNil: [^ self].
	mailDB remove: currentMsgID fromCategory: currentCategory.
	"remove the message from the listing"
	currentMessageIndex _ currentMessages indexOf: currentMsgID.
	currentMessages _ currentMessages copyWithout: currentMsgID.
	currentTOC _ currentTOC copyWithoutIndex: currentMessageIndex.
	1
		to: self tocLists size
		do: [:index | (tocLists at: index) removeAt: currentMessageIndex].
	"update the message index and message ID"
	currentMessages isEmpty
		ifTrue: [currentMsgID _ nil]
		ifFalse: [currentMsgID _ currentMessages
						at: (currentMessageIndex min: currentMessages size)].
	self changed: #tocEntryList.
	self changed: #tocEntry.
	self changed: #messageText