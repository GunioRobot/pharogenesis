setFilter
	filter _ FillInTheBlank request: 'Pattern for added test cases (#* OK)' initialAnswer: '*'.
	(filter endsWith: '*') ifFalse: [ filter _ filter, '*' ].
	selectedSuites _ (tests asOrderedCollection with: selectedSuites collect: [ :ea :sel |
		sel or: [ filter match: ea asString ]
	]).
	selectedSuite _ selectedSuites indexOf: true ifAbsent: [0].
	self changed: #allSelections.
