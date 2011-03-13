isWHQuestionClause
	| firstWordString |
	self isQuestionClause ifFalse: [^ false].
	firstWordString := clause phrases first words first string asLowercase.
	^ (firstWordString beginsWith: 'wh') or: [firstWordString = 'how']