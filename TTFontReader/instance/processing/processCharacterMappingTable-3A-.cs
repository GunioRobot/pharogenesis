processCharacterMappingTable: entry
	"Read the font's character to glyph index mapping table.
	If an appropriate mapping can be found then return an association
	with the format identifier and the contents of the table"
	| copy initialOffset nSubTables pID sID offset cmap assoc |
	initialOffset _ entry offset.
	entry skip: 2. "Skip table version"
	nSubTables _ entry nextUShort.
	1 to: nSubTables do:[:i|
		pID _ entry nextUShort.
		sID _ entry nextUShort.
		offset _ entry nextULong.
		"Check if this is either a Macintosh encoded table
		or a Windows encoded table"
		(pID = 1 or:[pID = 3]) ifTrue:[
			"Go to the beginning of the table"
			copy _ entry copy.
			copy offset: initialOffset + offset.
			cmap _ self decodeCmapFmtTable: copy.
			(pID = 1 and: [cmap notNil]) "Prefer Macintosh encoding over everything else"
				ifTrue: [^ pID -> cmap].
			assoc _ pID -> cmap. "Keep it in case we don't find a Mac encoded table"
		].
	].
	^assoc