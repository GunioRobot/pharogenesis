message
	"Answer the text of the currently selected message or nil if there isn't one."
self isThisEverCalled .
	(currentMsgID isNil)
		ifTrue: [^'']
		ifFalse: [^(mailDB getText: currentMsgID) asText]