jumpTo: aNode 
	| column ancestor |
	column := self columns first.
	
	[ancestor := column selectAncestorOf: aNode.
	ancestor = aNode or: [ancestor isNil]] whileFalse:
		[column := self columns after: column].
	
	self announcer announce: (OBSelectionChanged column: column)