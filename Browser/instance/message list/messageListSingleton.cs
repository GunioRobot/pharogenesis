messageListSingleton

	| name |
	name := self selectedMessageName.
	^ name ifNil: [Array new]
		ifNotNil: [Array with: name]