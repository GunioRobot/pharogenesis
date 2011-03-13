messageList

	| probe |
	currentClassName ifNil: [^ #()].
	probe _ (currentClassName endsWith: ' class')
		ifTrue: [currentClassName]
		ifFalse: [currentClassName asSymbol].
	^ ((myChangeSet selectorsInClass: probe) collect: 
					[:each | each printString]) asSortedCollection
