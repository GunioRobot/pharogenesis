string: aString onFileNumber: fileNumber
	"Store this as my string if source files exist."
	| theFile |
	(SourceFiles at: fileNumber) == nil ifFalse: 
		[theFile _ SourceFiles at: fileNumber.
		theFile setToEnd; cr.
		self string: aString onFileNumber: fileNumber toFile: theFile]