string: aString onFileNumber: anInteger
	"Store this as my string if source files exist."

	| theFile |
	(SourceFiles at: anInteger) == nil
		ifFalse: 
			[theFile _ SourceFiles at: anInteger.
			theFile setToEnd; cr.
			self string: aString
				onFileNumber: anInteger
				toFile: theFile]