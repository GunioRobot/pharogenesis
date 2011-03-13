update: aSymbol
	"Refer to the comment in View|update:."
	aSymbol == #wantToChange ifTrue: [^ self promptForCancel].
	aSymbol == #clearUserEdits ifTrue: [^ self hasUnacceptedEdits: false].
	aSymbol == #flash ifTrue: [^ controller flash].
	self updateDisplayContents