updateTOC
	"Update the table of contents; try to keep the currently selected message selectod, if possible"
	| savedMsgID newMsgID |
	mailDB ifNil: [ ^self ].
	savedMsgID _ currentMsgID.

	"update currentMessages, currentTOC"
	currentMessages _ self filteredMessages.


	"try to select the previously selected message; if impossible, select the  first message"
	currentMessages isEmptyOrNil
		ifFalse: [(currentMessages includes: savedMsgID)
				ifTrue: [newMsgID _ savedMsgID]
				ifFalse: [newMsgID _ currentMessages first]].
	self displayMessage: newMsgID.

	self changed: #tocEntryList.
	self changed: #tocEntryListAsStrings.
	self changed: #outBoxStatus