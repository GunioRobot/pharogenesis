setTOCIndex: newIndex
	| newMessageID |
	"Change the currently selected message.  Specify 0 to choose no message"
	newIndex = 0 ifTrue: [ ^self setMessageID: nil ].
	newMessageID _ currentMessages at: newIndex.
	self setMessageID: newMessageID.
	Celeste
		triggerEvent: #tocSelectedIndexChanged
		withArguments: {newMessageID. mailDB}.