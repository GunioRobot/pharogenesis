classListSingleton

	| name |
	name _ self selectedClassName.
	^ name ifNil: [Array new]
		ifNotNil: [Array with: name]