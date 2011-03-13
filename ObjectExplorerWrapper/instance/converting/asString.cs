asString
	| string |
	string _ itemName , ': ' , item asExplorerString.
	(string includes: Character cr)
		ifTrue: [^ string withSeparatorsCompacted].
	^ string