messageList 

	| probe newSelectors |
	currentClassName ifNil: [^ #()].
	probe _ (currentClassName endsWith: ' class')
		ifTrue: [currentClassName]
		ifFalse: [currentClassName asSymbol].
	newSelectors _ myChangeSet selectorsInClass: probe.
	(newSelectors includes: currentSelector) ifFalse: [currentSelector _ nil].
	^ newSelectors asSortedCollection
