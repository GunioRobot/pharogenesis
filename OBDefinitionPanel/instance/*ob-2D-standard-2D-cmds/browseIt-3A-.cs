browseIt: aSymbol
	| entry |
	entry := self selectedClass environment at: aSymbol ifAbsent: [nil].
	entry ifNil: [^ self implementorsOfIt: aSymbol].
	(entry isBehavior or: [entry isTrait ])
		ifFalse: [entry := entry class].
	OBSystemBrowser openOnClass: entry.
	^ true
	