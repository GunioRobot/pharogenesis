getterSelectorFor: aSymbol
	aSymbol == #isOverColor: ifTrue: [^ #seesColor:].
	^ Utilities getterSelectorFor: aSymbol