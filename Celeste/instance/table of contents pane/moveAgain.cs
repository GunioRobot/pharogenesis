moveAgain
	"Move the current message to the same category as last time."

	| newCatName |
	currentMsgID isNil ifTrue: [^self].	"If no message is selected, just return"

	(lastCategory isEmpty not)
		ifTrue: [newCatName _ lastCategory]
		ifFalse: [newCatName _ self getCategoryNameIfNone: [^self]].
	mailDB remove: currentMsgID fromCategory: currentCategory.
	mailDB file: currentMsgID inCategory: newCatName.
	self updateTOC.