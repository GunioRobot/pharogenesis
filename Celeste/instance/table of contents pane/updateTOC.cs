updateTOC
	"Update the table of contents after a moving, removing, or deleting a message. Select a message near the removed message in the table of contents if possible."

	| currentMsgIndex |
	(currentCategory isNil or:
	 [currentMsgID isNil or:
	 [currentMessages size < 2]])
		ifTrue: [currentMsgIndex _ 1]
		ifFalse: [currentMsgIndex _ currentMessages indexOf: currentMsgID].
	currentMsgID _ nil.
	self setCategory: currentCategory.  "update currentMessages, currentTOC"
	currentMessages isEmptyOrNil ifFalse: [
		(currentMsgIndex <= currentMessages size)
			ifTrue: [currentMsgID _ currentMessages at: currentMsgIndex]
			ifFalse: [currentMsgID _ currentMessages last].
	].

	"NB: self changed: #tocEntryList  is already done above by setCategory: and can be slow"
	self changed: #tocEntry.
	self changed: #messageText.
