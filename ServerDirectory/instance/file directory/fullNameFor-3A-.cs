fullNameFor: aFileName

	(aFileName includes: self pathNameDelimiter)
		ifTrue: [^ aFileName].
	^ server, self pathNameDelimiter asString, directory, 
		self pathNameDelimiter asString, aFileName