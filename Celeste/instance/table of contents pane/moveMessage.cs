moveMessage
	"Move the current message to another category; this consists of filing it in the new category, and then removing it from the current category"

	| newCatName |
	mailDB ifNil: [ ^self ].
	newCatName _ self getCategoryNameIfNone: [^self].
	newCatName = self category ifTrue: [ ^self ].
	mailDB file: currentMsgID inCategory: newCatName.

	self removeMessage.
