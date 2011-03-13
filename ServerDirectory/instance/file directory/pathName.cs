pathName

	directory size = 0 ifTrue: [^ server].
	^ (directory at: 1) = self pathNameDelimiter
		ifTrue: [server, directory]
		ifFalse: [server, self pathNameDelimiter asString, directory]