asString
	| s |
	s _ itemName , ': ' , item asExplorerString.
	(s includes: Character cr) ifTrue: [ s _ s withSeparatorsCompacted].
	^s