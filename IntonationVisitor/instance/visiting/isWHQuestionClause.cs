isWHQuestionClause
	| firstWordString |
	self isQuestionClause ifFalse: [^ false].
	firstWordString _ clause phrases first words first string asLowercase.
	^ (firstWordString beginsWith: 'wh') or: [firstWordString = 'how']