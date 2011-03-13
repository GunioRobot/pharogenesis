update: aSymbol 
	aSymbol == getListSelector
		ifTrue: [self list: self getList.
			^ self displayView; emphasizeView].
	aSymbol == getSelectionSelector
		ifTrue: [^ self displayView; emphasizeView].
	aSymbol == #allSelections
		ifTrue: [^ self displayView; emphasizeView].
	^ super update: aSymbol