tocIndex
	"return the index of the currently selected message in the TOC listing"
	currentMsgID ifNil: [ ^0 ].
	^currentMessages indexOf: currentMsgID