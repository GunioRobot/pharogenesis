printOn: aStream indent: level 
	aStream withAttributes: (Preferences syntaxAttributesFor: #variable)
		do: [aStream nextPutAll: name].
