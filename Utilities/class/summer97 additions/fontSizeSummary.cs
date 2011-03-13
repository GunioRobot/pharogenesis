fontSizeSummary
	"Utilities fontSizeSummary"

	| aStream aList |
	aStream _ ReadWriteStream on: ''.
	aList _ Utilities knownTextStyles.
	aList do: [:aStyleName |
		aStream nextPutAll:
			aStyleName, '  ',
			(Utilities fontSizesFor: aStyleName) asArray storeString.
		aStream cr].
	Utilities
		openScratchWorkspaceLabeled: 'Font styles and sizes'
		contents: aStream contents.
