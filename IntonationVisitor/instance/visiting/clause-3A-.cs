clause: aClause
	super clause: aClause.

	self isYesNoQuestionClause ifTrue: [^ clause accent: 'L- H%'].
	self isWHQuestionClause ifTrue: [^ clause accent: '%H H- L%'].
	clause accent: 'L- L%' "it's a declarative phrase"