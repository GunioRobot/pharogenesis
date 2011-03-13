setRoot: aString dataType: aSymbol
	assignmentRoot _ aString.
	assignmentSuffix _ ':'.
	dataType _ aSymbol.
	self updateLiteralLabel