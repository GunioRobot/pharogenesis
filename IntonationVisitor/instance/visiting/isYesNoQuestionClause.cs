isYesNoQuestionClause
	^ self isQuestionClause and: [self isWHQuestionClause not]