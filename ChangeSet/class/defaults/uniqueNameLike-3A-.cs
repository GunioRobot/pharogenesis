uniqueNameLike: aString

	| try |
	(ChangeSorter changeSetNamed: aString) ifNil: [^ aString].

	1 to: 999999 do:
		[:i | try _ aString , i printString.
		(ChangeSorter changeSetNamed: try) ifNil: [^ try]]