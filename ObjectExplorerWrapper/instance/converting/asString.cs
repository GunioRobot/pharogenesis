asString
	| explorerString string |
	explorerString _ 
		[item asExplorerString]
			on: Error 
			do: ['<error in asExplorerString: evaluate "' , itemName , ' asExplorerString" to debug>'].
	string _ (itemName ifNotNil: [itemName , ': '] ifNil: ['']) , explorerString.
	(string includes: Character cr)
		ifTrue: [^ string withSeparatorsCompacted].
	^ string