fileAgain
	"File the current message in the same category as last time."

	| newCatName |
	mailDB ifNil: [ ^self ].
	(lastCategory isEmpty not)
		ifTrue: [newCatName _ lastCategory]
		ifFalse: [newCatName _ self getCategoryNameIfNone: [^self]].
	mailDB file: currentMsgID inCategory: newCatName.
