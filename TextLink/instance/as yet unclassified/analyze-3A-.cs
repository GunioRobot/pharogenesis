analyze: aString

	| list |
	list _ super analyze: aString.
	classAndMethod _ list at: 1.
	^ list at: 2