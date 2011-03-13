setAttribute: aSymbol of: anObject to: value

	| attributes |
	attributes _ dictionaries at: anObject ifAbsentPut: [IdentityDictionary new].
	attributes at: aSymbol put: value.

