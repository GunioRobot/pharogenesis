save: aCategorizer into: aFileName
	| file |
	file _ FileStream fileNamed: aFileName.
	aCategorizer writeOn: file elementWriter: [:s :i | s nextInt32Put: i].
	file close.