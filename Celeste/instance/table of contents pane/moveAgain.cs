moveAgain
	"Move the current message to the same category as last time."

	| newCatName |
	currentMsgID ifNil: [ ^self ].
	(lastCategory isEmpty not)
		ifTrue: [newCatName _ lastCategory]
		ifFalse: [newCatName _ self getCategoryNameIfNone: [^self]].
	newCatName = self category ifTrue: [ ^self ].

	mailDB file: currentMsgID inCategory: newCatName.

	self removeMessage.