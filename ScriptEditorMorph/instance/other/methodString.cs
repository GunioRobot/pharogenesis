methodString
	"Answer the source-code string for the receiver.  This is for use by classic tiles, but is also used in universal tiles to formulate an initial method declaration for a nascent user-defined script; in universalTiles mode, the codeString (at present anyway) is empty -- the actual code derives from the SyntaxMorph in that case"

	^ String streamContents:
		[:aStream |
			aStream nextPutAll: scriptName.
			scriptName numArgs > 0 ifTrue:
				[aStream nextPutAll: ' parameter'].
			aStream cr; cr; tab.
			aStream nextPutAll: self codeString]
