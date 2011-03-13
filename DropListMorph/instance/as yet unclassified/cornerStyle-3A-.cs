cornerStyle: aSymbol
	"Pass on to list and button too."

	super cornerStyle: aSymbol.
	self listMorph cornerStyle: aSymbol.
	self buttonMorph cornerStyle: aSymbol.