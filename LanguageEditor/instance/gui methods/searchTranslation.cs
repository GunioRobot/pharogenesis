searchTranslation
	| search |
	search := FillInTheBlank request: 'search for' translated initialAnswer: ''.
	(search isNil
			or: [search isEmpty])
		ifTrue: [""
			self beep.
			^ self].
""
self searchTranslation: search