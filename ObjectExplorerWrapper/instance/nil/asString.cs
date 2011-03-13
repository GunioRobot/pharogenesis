asString
	| explorerString string |
	explorerString := 
		[item asExplorerString]
			on: Error 
			do: ['<error in asExplorerString: evaluate "' , itemName , ' asExplorerString" to debug>'].
	string := itemName , ': ' , explorerString.
	(string includes: Character cr)
		ifTrue: [^ string withSeparatorsCompacted].
	^ string