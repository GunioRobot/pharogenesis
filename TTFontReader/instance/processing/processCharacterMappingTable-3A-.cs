processCharacterMappingTable: entry
	"Read the font's character to glyph index mapping table.
	If an appropriate mapping can be found then return an association
	with the format identifier and the contents of the table"
	| copy initialOffset nSubTables pID sID offset cmap assoc |
	initialOffset := entry offset.
	entry skip: 2. "Skip table version"
	nSubTables := entry nextUShort.
	1 to: nSubTables do:[:i|
		pID := entry nextUShort.
		sID := entry nextUShort.
		offset := entry nextULong.
		"Check if this is either a Unicode (0), Macintosh (1),
		or a Windows (3) encoded table"
		(#(0 1 3) includes: pID) ifTrue:[
			"Go to the beginning of the table"
			copy := entry copy.
			copy offset: initialOffset + offset.
			cmap := self decodeCmapFmtTable: copy.
			(pID = 0 and: [cmap notNil]) "Prefer Unicode encoding over everything else"
				ifTrue: [^ pID -> cmap].
			assoc := pID -> cmap. "Keep it in case we don't find a better table"
		].
	].
	^assoc