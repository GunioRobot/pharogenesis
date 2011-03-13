moveMessage
	"Move the current message to another category; this consists of filing it in the new category, and then removing it from the current category"

	| newCatName |
	newCatName _ self getCategoryNameIfNone: [^self].
	newCatName = currentCategory ifTrue: [ ^self ].
	mailDB file: currentMsgID inCategory: newCatName.

	self removeMessage.
