update: aSymbol
	"Update the receiver in the manner suggested by aSymbol"

	aSymbol == #flash ifTrue: [^ self flash].
	(aSymbol == #contents or: [aSymbol == #tiles])
		ifTrue: [^ self containingWindow model installTilesForSelection]