analyze: aString

	| list |
	list _ super analyze: aString.
	url _ list at: 1.
	^ list at: 2