fileMessage
	"File the current message in another category."

	| newCatName |
	mailDB ifNil: [ ^self ].
	newCatName _ self getCategoryNameIfNone: [^self].
	mailDB file: currentMsgID inCategory: newCatName.
