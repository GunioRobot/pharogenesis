includesKey: aString
	"Answer whether the receiver includes an element of the given name."
	"Note: aString may designate a file local to this directory, or it may be a full path name. Try both."

	^ (StandardFileStream isAFileNamed: pathName, ':', aString) or:
		[StandardFileStream isAFileNamed: aString]