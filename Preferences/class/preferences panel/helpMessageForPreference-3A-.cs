helpMessageForPreference: aSymbol
	^ (self helpMessageOrNilForPreference: aSymbol) ifNil:
		['No help available for ', aSymbol]