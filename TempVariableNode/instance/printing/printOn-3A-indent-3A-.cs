printOn: aStream indent: level 
	aStream withAttributes: (Preferences syntaxAttributesFor: #temporaryVariable)
			do: [aStream nextPutAll: name]