fileAll
	"File all visible messages in the current category in some other category as well."

	| newCatName msgList |
	mailDB ifNil: [ ^self ].
	newCatName _ self getCategoryNameIfNone: [^self].
	msgList _ self filteredMessages.
	mailDB fileAll: msgList inCategory: newCatName.
	self updateTOC.