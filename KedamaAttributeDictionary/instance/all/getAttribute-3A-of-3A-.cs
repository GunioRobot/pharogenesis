getAttribute: aSymbol of: anObject

	| attributes |
	attributes _ dictionaries at: anObject ifAbsent: [^ nil].
	^ attributes at: aSymbol ifAbsent: [nil].
