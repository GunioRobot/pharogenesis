controlActivity 

	shownAsComplemented ifNil: [^ self].
	shownAsComplemented = self viewHasCursor
		ifFalse:
			[view ifNotNil: [view toggleMouseOverFeedback]. 
			shownAsComplemented := shownAsComplemented not]