isNewMessage: msg inCategory: categoryName withProbability: threshold
	| inCategory |
	inCategory _ self isMessage: msg inCategory: categoryName withProbability: threshold.
	(inCategory ifTrue: [categorizer categoryNamed: categoryName] ifFalse: [categorizer oppositeCategoryOf: categoryName]) addAll: msg tokens.
	^ inCategory