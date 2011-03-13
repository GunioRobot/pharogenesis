update: aSymbol
	aSymbol == #flash ifTrue: [^ self flash].
	aSymbol == getTextSelector ifTrue:
			[self setText: self getText.
			^ self setSelection: self getSelection].
	aSymbol == getSelectionSelector ifTrue: [^ self setSelection: self getSelection].
	aSymbol == #autoSelect ifTrue:
			[self handleEdit:
				[textMorph editor setSearch: model autoSelectString;
							againOrSame: true]].
	aSymbol == #clearUserEdits ifTrue: [^ self hasUnacceptedEdits: false].
	aSymbol == #wantToChange ifTrue:
			[self canDiscardEdits ifFalse: [^ self promptForCancel].
			^ self].
	aSymbol == #appendEntry ifTrue:
			[self handleEdit: [self appendEntry].
			^ self world displayWorld].
	aSymbol == #clearText ifTrue:
			[self handleEdit: [self changeText: Text new].
			^ self world displayWorld].
