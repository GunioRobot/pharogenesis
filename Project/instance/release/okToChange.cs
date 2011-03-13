okToChange

	| ok |
	ok _ (world isMorph not and: [world scheduledControllers size <= 1]) or:
			[self confirm:
'Really delete the project
', self name printString, '
and all its windows?'].
	ok ifFalse: [^ false].

	"about to delete this project; clear previous links to it from other Projects:"
	Project allInstancesDo: [:p | p deletingProject: self].
	^ true
