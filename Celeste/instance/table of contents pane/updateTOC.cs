updateTOC
	"Update the table of contents after a moving, removing, or deleting a message. Select a message near the removed message in the table of contents if possible."

	| savedMsgID |
	"remember the currently selected message"
	savedMsgID _ currentMsgID.

	"update the TOC listing"
	currentMsgID _ nil.
	self setCategory: currentCategory.  "update currentMessages, currentTOC"

	"try to select the previously selected message; if impossible, select the first message"
	currentMessages isEmptyOrNil ifFalse: [
		(currentMessages includes: savedMsgID) 
			ifTrue: [ currentMsgID _ savedMsgID ]
			ifFalse: [ currentMsgID _ currentMessages first ] ].

	"NB: self changed: #tocEntryList  is already done above by setCategory: and can be slow"
	self changed: #tocEntry.
	self changed: #messageText.
