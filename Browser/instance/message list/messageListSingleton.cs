messageListSingleton

	| name |
	name _ self selectedMessageName.
	^ name ifNil: [Array new]
		ifNotNil: [Array with: name]