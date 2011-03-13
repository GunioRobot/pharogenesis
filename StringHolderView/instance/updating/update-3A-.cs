update: aSymbol
	"Refer to the comment in View|update:."
	aSymbol == #wantToChange ifTrue: [^ self promptForCancel].
	aSymbol == #flash ifTrue: [^ controller flash].
	self updateDisplayContents