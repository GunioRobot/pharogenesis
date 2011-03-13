fileMessage
	"File the current message in another category."

	| newCatName |
	newCatName _ self getCategoryNameIfNone: [^self].
	mailDB file: currentMsgID inCategory: newCatName.
