analyze: aString

	| list |
	list _ super analyze: aString.
	evalString _ list at: 1.
	^ list at: 2