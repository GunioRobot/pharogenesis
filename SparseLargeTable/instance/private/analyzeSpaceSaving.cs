analyzeSpaceSaving

	| total elems tablesTotal nonNilTables |
	total _ size - base + 1.
	elems _ 0.
	base to: size do: [:i | (self at: i) ~= defaultValue ifTrue: [elems _ elems + 1]].
	tablesTotal _ self basicSize.
	nonNilTables _ 0.
	1 to: self basicSize do: [:i | (self basicAt: i) ifNotNil: [nonNilTables _ nonNilTables + 1]].

	^ String streamContents: [:strm |
		strm nextPutAll: 'total: '.
		strm nextPutAll: total printString.
		strm nextPutAll: ' elements: '.
		strm nextPutAll: elems printString.
		strm nextPutAll: ' tables: '.
		strm nextPutAll: tablesTotal printString.
		strm nextPutAll: ' non-nil: '.
		strm nextPutAll: nonNilTables printString.
	].

