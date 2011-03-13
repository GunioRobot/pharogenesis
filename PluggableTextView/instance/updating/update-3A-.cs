update: aSymbol
	"Refer to the comment in View|update:. Do nothing if the given symbol does not match any action."

	aSymbol == #wantToChange ifTrue:
			[self canDiscardEdits ifFalse: [self promptForCancel].  ^ self].
	aSymbol == #flash ifTrue: [^ controller flash].
	aSymbol == getTextSelector ifTrue: [^ self updateDisplayContents].
	aSymbol == getSelectionSelector ifTrue: [^ self setSelection: self getSelection].
	aSymbol == #clearUserEdits ifTrue: [^ self hasUnacceptedEdits: false].
	aSymbol == #autoSelect ifTrue:
			[^ controller setSearch: model autoSelectString;
					againOrSame: true].
	aSymbol == #appendEntry ifTrue:
			[^ controller doOccluded: [controller appendEntry]].
	aSymbol == #clearText ifTrue:
			[^ controller doOccluded:
				[controller changeText: Text new]].
